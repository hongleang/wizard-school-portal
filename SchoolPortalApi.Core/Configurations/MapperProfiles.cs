using AutoMapper;
using SchoolPortalApi.Core.DTOs.CharacterDtos;
using SchoolPortalApi.Core.DTOs.HouseDtos;
using SchoolPortalApi.Data.Entities;
using SchoolPortalAPI.DTOs.UserDtos;
using SchoolPortalAPI.Entities;

namespace SchoolPortalApi.Core.Configurations
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            // House mapping config
            CreateMap<House, ViewHouseDto>()
                .ForMember(dest => dest.FounderName, opt => opt.MapFrom(src => src.Founder.Name))
                .ReverseMap();
            CreateMap<House, ViewHouseDto>()
                .ForMember(dest => dest.FounderName, opt => opt.MapFrom(src => src.Founder.Name))
                .ReverseMap();
            CreateMap<House, UpdateHouseDto>().ReverseMap();
            
            // Character mapping config
            CreateMap<Character, ViewCharacterDto>()
                .ForMember(dest => dest.HouseName, opt => opt.MapFrom(src => src.House.Name))
                .ReverseMap();
            CreateMap<Character, UpdateCharacterDto>().ReverseMap();

            // User mapping config
            CreateMap<User, RegisterDto>().ReverseMap();

        }
    }
}
