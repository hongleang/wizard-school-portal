using Microsoft.AspNetCore.Identity;
using SchoolPortalAPI.DTOs.UserDtos;

namespace SchoolPortalApi.Core.Interfaces.IAauthManager
{
    public interface IAuthManager
    {
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<UserDto> GetUserAsync(string username);
        Task<UserDto> Login(LoginDto login);
        Task<IdentityResult> Register(RegisterDto register);
    }
}
