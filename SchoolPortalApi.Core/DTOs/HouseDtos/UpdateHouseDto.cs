using SchoolPortalApi.Core.DTOs.CharacterDtos;
using SchoolPortalAPI.Entities;

namespace SchoolPortalApi.Core.DTOs.HouseDtos
{
    public class UpdateHouseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Motto { get; set; }
        public string LogoUrl { get; set; }
    }
}
