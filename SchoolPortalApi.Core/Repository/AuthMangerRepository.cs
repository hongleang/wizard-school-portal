using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SchoolPortalApi.Core.Interfaces;
using SchoolPortalApi.Core.Interfaces.IAauthManager;
using SchoolPortalApi.Data.Entities;
using SchoolPortalAPI.DTOs.UserDtos;

namespace SchoolPortalApi.Core.Repository
{
    public class AuthMangerRepository : IAuthManager
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly ITokenServices _tokenServices;

        public AuthMangerRepository(UserManager<User> userManager,
            IMapper mapper,
            ITokenServices tokenServices)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenServices = tokenServices;
        }

        public async Task<UserDto> GetUserAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _userManager.GetUsersInRoleAsync("user");
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> Login(LoginDto login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);
            bool validUser = await _userManager.CheckPasswordAsync(user, login.Password);


            var token = await _tokenServices.CreateToken(user);

            return new UserDto()
            {
                Username = user.UserName,
                Token = token
            };
        }

        public async Task<IdentityResult> Register(RegisterDto register)
        {
            var newUser = _mapper.Map<User>(register);
            var result = await _userManager.CreateAsync(newUser, register.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, "user");
                return null;
            }
            return result;
        }
    }
}
