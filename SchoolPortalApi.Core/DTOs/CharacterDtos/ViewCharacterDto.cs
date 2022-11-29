using SchoolPortalAPI.Entities;

namespace SchoolPortalApi.Core.DTOs.CharacterDtos
{
    public class ViewCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public string HouseName { get; set; }
    }
}
