using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolPortalApi.Core.DTOs.CharacterDtos;
using SchoolPortalApi.Core.Interfaces.IRepositories;
using SchoolPortalAPI.Data;
using SchoolPortalAPI.Entities;

namespace SchoolPortalApi.Core.Repository
{
    public class CharacterRepository : GenericRepository<Character>, ICharacterRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CharacterRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ViewCharacterDto?> GetCharacterDetails(int id)
        {
            var entity = await _context.Characters
                    .Include(x => x.House)
                    .FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<ViewCharacterDto>(entity);
        }
    }
}
