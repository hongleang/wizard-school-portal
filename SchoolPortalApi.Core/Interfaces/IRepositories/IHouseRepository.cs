using SchoolPortalAPI.Entities;

namespace SchoolPortalApi.Core.Interfaces.IRepositories
{
    public interface IHouseRepository : IGenericRepository<House>
    {
        Task<House> GetHouseDetails();
    }
}
