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

        public UserService(IUserRepository userRepository, 
                        IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public UserModel GetCurrentUser()
        {
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var claims = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
                var id = int.Parse(claims.FindFirst(ClaimTypes.Sid).Value.ToString());
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

        public IEnumerable<UserModel> GetUsersByRole(int roleId)
        {
            //var userRoles = _userRoleRepository.Filter(x => x.RoleId == roleId);
            //var user = userRoles.Select(x => _userRepository.GetById(x.UserId)).ToList();
            //return _mapper.Map<IEnumerable<User>, IEnumerable<UserModel>>(user);
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetUsers()
        {
            var users = _userRepository.GetAll();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserModel>>(users);
        }

        public void CreateUser(UserModel model)
        {
            _userRepository.Insert(_mapper.Map<UserModel, User>(model));
            _userRepository.Save();
        }

        public void UpdateUser(UserModel model)
        {
            _userRepository.Update(_mapper.Map<UserModel, User>(model));
            _userRepository.Save();
        }

        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
            _userRepository.Save();
        }

        public void SetUserStatus(int userId, int status)
        {
            var user = _userRepository.GetById(userId);
            user.Status = status;
            _userRepository.Insert(user);
            _userRepository.Save();
        }

        public void SetUserRole(int userId, int roleId)
        {
            //_userRoleRepository.Insert(new User_Role()
            //{
            //    UserId = userId,
            //    RoleId = roleId
            //});
            //_userRoleRepository.Save();
        }

        public void RemoveUserRole(int userId, int roleId)
        {
        //    _userRoleRepository.Delete(userId, roleId);
        //    _userRoleRepository.Save();
        }
    }
}
