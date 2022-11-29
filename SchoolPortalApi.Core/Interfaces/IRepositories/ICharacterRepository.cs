using SchoolPortalApi.Core.DTOs.CharacterDtos;
using SchoolPortalAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPortalApi.Core.Interfaces.IRepositories
{
    public interface ICharacterRepository : IGenericRepository<Character>
    {
        Task<ViewCharacterDto> GetCharacterDetails(int id);
    }
}
