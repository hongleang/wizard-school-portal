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
        public string Username { get; set; }

        [Required]
        [MaxLength(20)]
        public string Password { get; set; }

        [Required]
        public string Species { get; set; }

        [Required]
        public int HouseId { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
