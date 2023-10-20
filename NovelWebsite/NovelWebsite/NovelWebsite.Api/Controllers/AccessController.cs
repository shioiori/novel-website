

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Domain.Services;

namespace NovelWebsite.NovelWebsite.Api.Controllers
{
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IMailService _mailService;

        public AccessController(IAuthenticationService authenticationService, 
                                IAuthorizationService authorizationService,
                                IMailService mailService)
        {
            _authenticationService = authenticationService;
            _authorizationService = authorizationService;
            _mailService = mailService;
        }


        [HttpPost]
        [Route("/login")]
        public async Task<AuthenticationResponse> LoginAsync(LoginRequest request)
        {
            var response = _authenticationService.Login(request);
            if (response.Success)
            {
                var user = JsonConvert.DeserializeObject<UserModel>(response.Context);
                await _authorizationService.SetClaims(user, request.LoginProvider);
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
        [Route("/logout")]
        public string Logout(string returnUrl)
        {
            _authorizationService.RemoveClaims();
            return returnUrl;
        }

        [HttpGet]
        [Route("/email-confimation")]
        public AuthenticationResponse EmailConfimation(string email, string token)
        {
            var response = _mailService.ConfirmEmail(email, token);
            return response;
        }   
    }
}
