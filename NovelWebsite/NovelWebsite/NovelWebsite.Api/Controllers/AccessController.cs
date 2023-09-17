﻿

using MailKit;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Domain.Services;

namespace NovelWebsite.NovelWebsite.Api.Controllers
{
    [ApiController]
    [Route("/access")]
    public class AccessController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAuthorizationService _authorizationService;

        public AccessController(IAuthenticationService authenticationService, IAuthorizationService authorizationService)
        {
            _authenticationService = authenticationService;
            _authorizationService = authorizationService;
        }


        [HttpPost]
        [Route("/login")]
        public async Task<AuthenticationResponse> LoginAsync(LoginRequest request)
        {
            var response = _authenticationService.Login(request);
            if (response.Success)
            {
                var account = JsonConvert.DeserializeObject<AccountModel>(response.Context);
                await _authorizationService.SetClaims(account, request.LoginProvider);
            }
            return response;
        }

        [HttpPost]
        [Route("/register")]
        public async Task<AuthenticationResponse> RegisterAsync(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                var error = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).First();
                return new AuthenticationResponse()
                {
                    Success = false,
                    Message = error,
                };
            }
            var response = await _authenticationService.RegisterAsync(request);
            return response;
        }

        [HttpGet]
        [Route("/signout")]
        public string Signout(string returnUrl)
        {
            _authorizationService.RemoveClaims();
            return returnUrl;
        }

    }
}
