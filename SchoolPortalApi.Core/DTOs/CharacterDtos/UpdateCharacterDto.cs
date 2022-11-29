namespace SchoolPortalApi.Core.DTOs.CharacterDtos
{
    public class UpdateCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public int HouseId { get; set; }
    }
}
