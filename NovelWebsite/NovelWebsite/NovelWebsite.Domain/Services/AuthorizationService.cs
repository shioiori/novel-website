using AutoMapper;
using Newtonsoft.Json;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AuthorizationService(IUserRepository userRepository, IAccountRepository accountRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public AuthorizationResponse Login(LoginRequest loginRequest)
        {
            var account = _accountRepository.GetAccount(loginRequest.Username, loginRequest.Password);
            if (account == null)
            {
                return new AuthorizationResponse()
                {
                    Success = false,
                    Message = "Tài khoản hoặc mật khẩu không đúng",
                };
            }
            return new AuthorizationResponse()
            {
                Success = true,
                Message = "Đăng nhập thành công",
                Context = JsonConvert.SerializeObject(account),
            };
        }
    }
}
