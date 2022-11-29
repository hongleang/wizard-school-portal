using Microsoft.AspNetCore.Identity;
using SchoolPortalAPI.Entities;

namespace SchoolPortalApi.Data.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string? ImageUrl { get; set; } = null;
        public DateTime DateOfBirth { get; set; }
        public int HouseId { get; set; }
        public House House { get; set; }
    }
}
