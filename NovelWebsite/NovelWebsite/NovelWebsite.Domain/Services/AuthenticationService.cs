using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Models.MailKit;
using NovelWebsite.NovelWebsite.Domain.Utils;

namespace NovelWebsite.NovelWebsite.Domain.Services
{

    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;

        Expression<Func<User, bool>> expUsername(string username)
        {
            return x => x.Username == username;
        }
        Expression<Func<User, bool>> expEmail(string email)
        {
            return x => x.Email == email;
        }
        Expression<Func<User, bool>> expLogin(string username, string password)
        {
            return x => x.Username == username && x.Password == password;
        }

        public AuthenticationService(IConfiguration config, 
                                    IUserRepository userRepository, 
                                    IMapper mapper, 
                                    IMailService mailService,
                                    IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _userRepository = userRepository;
            _mapper = mapper;
            _mailService = mailService;
            _httpContextAccessor = httpContextAccessor;
        }

        public AuthenticationResponse Login(LoginRequest loginRequest)
        {
            var user = _userRepository.IfExistsUser(expLogin(loginRequest.Username, loginRequest.Password));
            if (user == null)
            {
                return new AuthenticationResponse()
                {
                    Success = false,
                    Message = "Tài khoản hoặc mật khẩu không đúng",
                };
            }
            if (user.Status == (int)AccountStatus.Verifying)
            {
                return new AuthenticationResponse()
                {
                    Success = false,
                    Message = "Email chưa được xác nhận. Hãy kiểm tra lại email của bạn",
                };
            }
            var obj = _mapper.Map<User, UserModel>(user);
            return new AuthenticationResponse()
            {
                Success = true,
                Message = "Đăng nhập thành công",
                Context = JsonConvert.SerializeObject(obj),
            };
        }

        public async Task<AuthenticationResponse> RegisterAsync(RegisterRequest request){
            var validate = ValidateField(request);
            if (!validate.Success){
                return validate;
            }
            _userRepository.Insert(_mapper.Map<RegisterRequest, User>(request));
            _userRepository.Save();
            var user = _mapper.Map<RegisterRequest, UserModel>(request);
            var token = AesOperation.EncryptString(JsonConvert.SerializeObject(user));
            var confirmUrl = "https://" + _httpContextAccessor.HttpContext.Request.Host + "/email-confimation?email=" + request.Email + "&token=" + token;
            var content = new MailContent()
            {
                To = request.Email,
                Subject = "Xác minh tài khoản Novel Website",
                Body = EmailTemplate.GenerateEmailTemplate(user.Username, confirmUrl)
            };
            await _mailService.SendMail(content);
            validate.Message = "Một email đã được gửi đến hộp thư của bạn. Hãy xác nhận để xác minh danh tính người dùng";
            return validate;
        }

        public AuthenticationResponse ValidateField(RegisterRequest request){
            var user = _userRepository.IfExistsUser(expUsername(request.Username));
            if (user != null){
                return new AuthenticationResponse(){
                    Success = false,
                    Message = "Tên tài khoản này đã có người đăng ký",
                };
            }
            user = _userRepository.IfExistsUser(expEmail(request.Email));
            if (user != null){
                return new AuthenticationResponse(){
                    Success = false,
                    Message = "Email này đã được đăng ký",
                };
            }
            return new AuthenticationResponse(){
                Success = true,
            };
        }

    }
}
