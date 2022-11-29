﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SchoolPortalApi.Core.Exceptions;
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

        public async Task<UserDto> GetUserAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) throw new NotFoundException(
                $"Can't find a user with a email of {email}"
            );

            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _userManager.GetUsersInRoleAsync("user");
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> Login(LoginDto login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            bool validUser = await _userManager.CheckPasswordAsync(user, login.Password);

            if (user == null) throw new NotFoundException(
                $"Can't find a user with an email {login.Email}"
            );

            if (!validUser) throw new UnAuthorizedException(
                $"Password doesn't match with user: ${login.Email}"
            );

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
