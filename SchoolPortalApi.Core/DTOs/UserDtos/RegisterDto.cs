using System.ComponentModel.DataAnnotations;

namespace SchoolPortalAPI.DTOs.UserDtos
{
    public class RegisterDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }
        public string? ImageUrl { get; set; } = null;

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int HouseId { get; set; }
    }
}
