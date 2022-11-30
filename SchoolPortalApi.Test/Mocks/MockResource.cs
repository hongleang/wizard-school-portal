using SchoolPortalApi.Core.DTOs.CharacterDtos;
using SchoolPortalApi.Core.DTOs.HouseDtos;
using SchoolPortalAPI.Entities;

namespace SchoolPortalApi.Test.Mocks
{
    public class MockResource
    {
        private IEnumerable<ViewCharacterDto> _characters;
        private IEnumerable<ViewHouseDto> _houses;
        public IEnumerable<ViewCharacterDto> ListOfCharacters => _characters;
        public IEnumerable<ViewHouseDto> ListOfHouses => _houses;
        public MockResource()
        {
            _characters = new List<ViewCharacterDto>()
            {
                new ViewCharacterDto()
                {
                    Id=1,
                    Name = "Henry",
                    Gender = "male",
                    ImageUrl = "images/image-of-henry-the-good",
                    HouseName = "Huffle Puff"
                },
                new ViewCharacterDto()
                {
                    Id=2,
                    Name = "Jamie",
                    Gender = "male",
                    ImageUrl = "images/image-of-jamie-the-bold",
                    HouseName = "Gryffindor"
                }
            };

            _houses = new List<ViewHouseDto>()
            {
                new ViewHouseDto()
                {
                    Characters = (ICollection<ViewCharacterDto>)_characters,
                    FounderName = "testing-founder-1",
                    Id = 1,
                    LogoUrl = "somethinglogo-1",
                    Motto = "somthingmotto-1",
                    Name = "somethinghouse-1",
                    Value = "value-something-1",
                },
                new ViewHouseDto()
                {
                    Characters = (ICollection<ViewCharacterDto>)_characters,
                    FounderName = "testing-founder-2",
                    Id = 1,
                    LogoUrl = "somethinglogo-2",
                    Motto = "somthingmotto-2",
                    Name = "somethinghouse-2",
                    Value = "value-something-2",
                }
            };
        }

    }
}
