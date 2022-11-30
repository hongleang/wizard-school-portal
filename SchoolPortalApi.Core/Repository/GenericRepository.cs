using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolPortalApi.Core.Interfaces.IRepositories;
using SchoolPortalAPI.Data;

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

        public virtual async Task<TResult?> GetAsync<TResult>(int? id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return _mapper.Map<TResult>(entity);
        }
        public async Task AddAsync<TSource, TResult>(TSource entity)
        {
            var newEntity = _mapper.Map<T>(entity);

            await _context.Set<T>().AddAsync(newEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync<TSource>(int id, TSource newEntity)
        {
            var entity = await GetAsync<T>(id);

            _mapper.Map(newEntity, entity);

            if (entity == null) return false;

            try
            {
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception($"Something went wrong while saving {entity.GetType()} to DbSet", ex);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            if (entity == null) return false;

            try
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Something went wrong while saving {entity.GetType()} to DbSet", ex);
            }            
        }
    }
}
