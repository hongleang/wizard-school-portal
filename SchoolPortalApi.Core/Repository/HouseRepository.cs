using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolPortalApi.Core.Exceptions;
using SchoolPortalApi.Core.Interfaces.IRepositories;
using SchoolPortalAPI.Data;
using SchoolPortalAPI.Entities;

namespace SchoolPortalApi.Core.Repository
{
    public class HouseRepository : GenericRepository<House>, IHouseRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public HouseRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<House> GetHouseDetails()
        {
            return Task.FromResult(new House());
        }

        public override async Task<IEnumerable<TResult>> GetAllAsync<TResult>()
        {
            var entities = await _context.Houses
                .Include(x => x.Characters)
                .Include(x => x.Founder)
                .ToListAsync();

            return _mapper.Map<IEnumerable<TResult>>(entities);
        }

        public override async Task<TResult> GetAsync<TResult>(int? id)
        {
            var entity = await _context.Houses
                .Include(x => x.Characters)
                .Include(x => x.Founder)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new NotFoundException($"Can't find an entity with an id of '{id}' while processing {nameof(GetAsync)}");
            };

            return _mapper.Map<TResult>(entity);
        }
    }
}
