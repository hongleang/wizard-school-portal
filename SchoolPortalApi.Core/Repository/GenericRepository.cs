using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolPortalApi.Core.Exceptions;
using SchoolPortalApi.Core.Interfaces.IRepositories;
using SchoolPortalAPI.Data;
using SchoolPortalAPI.Entities;

namespace SchoolPortalApi.Core.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GenericRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public virtual async Task<IEnumerable<TResult>> GetAllAsync<TResult>()
        {
            var entities = await _context.Set<T>().ToListAsync();
            return _mapper.Map<IEnumerable<TResult>>(entities);
        }

        public virtual async Task<TResult> GetAsync<TResult>(int? id)
        {
            if(id == null) return default;

            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new NotFoundException($"Can't find an entity with an id of '{id}' while processing {nameof(GetAsync)}");
            };
            return _mapper.Map<TResult>(entity);
        }
        public async Task<TResult> AddAsync<TSource, TResult>(TSource entity)
        {
            var newEntity = _mapper.Map<T>(entity);

            await _context.Set<T>().AddAsync(newEntity);
            await _context.SaveChangesAsync();

            return _mapper.Map<TResult>(newEntity);
        }

        public async Task UpdateAsync<TSource>(int id, TSource newEntity)
        {
            var entity = await GetAsync<T>(id);

            if (entity == null)
            {
                throw new NotFoundException($"Can't find an entity with an id of '{id}' while processing {nameof(UpdateAsync)}");
            };

            _mapper.Map(newEntity, entity);

            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            
            if (entity == null)
            {
                throw new NotFoundException($"Can't find an entity with an id of '{id}' while processing {nameof(DeleteAsync)}");
            }

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> EnitityExists(int id)
        {
            var exists = await _context.Set<T>().FindAsync(id);
            return exists != null ? true : false;
        }
    }
}
