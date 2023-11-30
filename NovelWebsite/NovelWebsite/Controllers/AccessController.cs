

using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Application.Models.Request;
using NovelWebsite.Application.Models.Response;
using NovelWebsite.Application.Services;

namespace NovelWebsite.Controllers
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
            _mailService = mailService;
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
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            var user = (await _accessService.RegisterAsync(request)).User;
            await _mailService.GenerateEmailConfimationAsync(user);
            return new AuthenticationResponse()
            {
                Success = true,
                Message = "Please check your mail to confirm your account",
                StatusCode = StatusCodes.Status200OK,
            };
        }


        [HttpGet]
        [Route("/email-verify")]
        public async Task<AuthenticationResponse> EmailConfimation(string email, string token)
        {
            try
            {
                await _mailService.ConfirmEmailAsync(email, token);
                return new AuthenticationResponse()
                {
                    Success = true,
                    Message = "Email confimation success. Now you can login normally",
                    StatusCode = StatusCodes.Status202Accepted,
                };
            }
            catch (Exception ex)
            {
                return new AuthenticationResponse()
                {
                    Success = false,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };

            }
        }
    }
}
