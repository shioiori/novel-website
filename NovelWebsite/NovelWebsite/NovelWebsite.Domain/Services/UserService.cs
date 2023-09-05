using AutoMapper;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using System.Security.Claims;

namespace NovelWebsite.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUserRepository userRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public UserModel GetCurrentUser()
        {
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var id = int.Parse(((ClaimsIdentity)_httpContextAccessor.HttpContext.User.Identity).FindFirst(ClaimTypes.Sid).ToString());
                var user = _userRepository.GetById(id);
                return _mapper.Map<User, UserModel>(user);
            }
            return null;
        }

        public UserModel GetUserById(int id)
        {
            var user = _userRepository.GetById(id);
            return _mapper.Map<User, UserModel>(user);
        }

        public IEnumerable<UserModel> GetUsers()
        {
            var users = _userRepository.GetAll();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserModel>>(users);
        }

        public void CreateUser(UserModel model)
        {
            _userRepository.Insert(_mapper.Map<UserModel, User>(model));
        }

        public void UpdateUser(UserModel model)
        {
            _userRepository.Update(_mapper.Map<UserModel, User>(model));
        }

        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
        }
    }
}
