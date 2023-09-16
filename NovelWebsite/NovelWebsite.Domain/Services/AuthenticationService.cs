using System.Linq.Expressions;
using AutoMapper;
using Newtonsoft.Json;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Domain.Services
{

    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        
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

        public AuthenticationService(IUserRepository userRepository, IAccountRepository accountRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _mapper = mapper;
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
            return new AuthenticationResponse()
            {
                Success = true,
                Message = "Đăng nhập thành công",
                Context = JsonConvert.SerializeObject(account),
            };
        }

        public AuthenticationResponse Register(RegisterRequest request){
            var validate = ValidateField(request);
            if (!validate.Success){
                return validate;
            }
            _accountRepository.Insert(_mapper.Map<RegisterRequest, Account>(request));
            _userRepository.Insert(_mapper.Map<RegisterRequest, User>(request));
            validate.Message = "Đăng ký thành công";
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
