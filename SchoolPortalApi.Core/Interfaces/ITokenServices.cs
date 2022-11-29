using SchoolPortalApi.Data.Entities;

namespace SchoolPortalApi.Core.Interfaces
{
    public interface ITokenServices
    {
        Task<string> CreateToken(User user);
    }
}
