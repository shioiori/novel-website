

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Models.Request;
using NovelWebsite.NovelWebsite.Domain.Services;

namespace NovelWebsite.NovelWebsite.Api.Controllers
{
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly AccessService _accessService;
        private readonly MailService _mailService;

        public AccessController(AccessService accessService,
                                MailService mailService)
        {
            _accessService = accessService;
        }


        [HttpPost]
        [Route("/login")]
        public async Task<AuthenticationResponse> LoginAsync(LoginRequest request)
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
            return await _accessService.LoginAsync(request);
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
            return await _accessService.RegisterAsync(request);
        }


        [HttpGet]
        [Route("/email-verify")]
        public async Task<AuthenticationResponse> EmailConfimation(string email, string token)
        {
            return await _accessService.ConfirmEmailAsync(email, token);
        }   
    }
}
