using Microsoft.Build.Framework;

namespace SchoolPortalApi.Core.DTOs.CharacterDtos
{
    public class CreateCharacterDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }
        public string ImageUrl { get; set; }

        [Required]
        public int HouseId { get; set; }
    }
}
