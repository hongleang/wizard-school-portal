using SchoolPortalApi.Core.DTOs.CharacterDtos;
using SchoolPortalAPI.Entities;

namespace SchoolPortalApi.Core.DTOs.HouseDtos
{
    public class ViewHouseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Motto { get; set; }
        public string LogoUrl { get; set; }
        public string FounderName { get; set; }
        public ICollection<ViewCharacterDto> Characters { get; set; }
    }
}
