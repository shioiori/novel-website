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
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;

        Expression<Func<Account, bool>> expUsername(string username)
        {
            return x => x.Username == username;
        }
        Expression<Func<Account, bool>> expEmail(string email)
        {
            return x => x.Email == email;
        }
        Expression<Func<Account, bool>> expLogin(string username, string password)
        {
            return x => x.Username == username && x.Password == password;
        }

        public AuthenticationService(IConfiguration config, 
                                    IUserRepository userRepository, 
                                    IAccountRepository accountRepository, 
                                    IMapper mapper, 
                                    IMailService mailService,
                                    IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _mapper = mapper;
            _mailService = mailService;
            _httpContextAccessor = httpContextAccessor;
        }

        public AuthenticationResponse Login(LoginRequest loginRequest)
        {
            var account = _accountRepository.IfExistsAccount(expLogin(loginRequest.Username, loginRequest.Password));
            if (account == null)
            {
                return new AuthenticationResponse()
                {
                    Success = false,
                    Message = "Tài khoản hoặc mật khẩu không đúng",
                };
            }
            if (account.Status == (int)AccountStatus.Verifying)
            {
                return new AuthenticationResponse()
                {
                    Success = false,
                    Message = "Email chưa được xác nhận. Hãy kiểm tra lại email của bạn",
                };
            }
            var obj = _mapper.Map<Account, AccountModel>(account);
            obj.User = _mapper.Map<User, UserModel>(_userRepository.GetByExpression(x => x.AccountId == obj.Id));
            obj.UserId = obj.User.UserId;
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
            _accountRepository.Insert(_mapper.Map<RegisterRequest, Account>(request));
            _accountRepository.Save();
            var account = _accountRepository.GetAccountByEmail(request.Email);
            var user = _mapper.Map<RegisterRequest, UserModel>(request);
            user.AccountId = account.Id;
            var token = AesOperation.EncryptString(JsonConvert.SerializeObject(user));
            var confirmUrl = "https://" + _httpContextAccessor.HttpContext.Request.Host + "/email-confimation?email=" + request.Email + "&token=" + token;
            var content = new MailContent()
            {
                To = request.Email,
                Subject = "Xác minh tài khoản Novel Website",
                Body = EmailTemplate.GenerateEmailTemplate(account.Username, confirmUrl)
            };
            await _mailService.SendMail(content);
            validate.Message = "Một email đã được gửi đến hộp thư của bạn. Hãy xác nhận để xác minh danh tính người dùng";
            return validate;
        }

        public AuthenticationResponse ValidateField(RegisterRequest request){
            var account = _accountRepository.IfExistsAccount(expUsername(request.Username));
            if (account != null){
                return new AuthenticationResponse(){
                    Success = false,
                    Message = "Tên tài khoản này đã có người đăng ký",
                };
            }
            account = _accountRepository.IfExistsAccount(expEmail(request.Email));
            if (account != null){
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
