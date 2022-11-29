namespace SchoolPortalApi.Core.Interfaces.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<TResult>> GetAllAsync<TResult>();
        Task<TResult> GetAsync<TResult>(int? id);
        Task<TResult> AddAsync<TSource, TResult>(TSource entity);
        Task UpdateAsync<TSource>(int id, TSource entity);
        Task DeleteAsync(int id);
        Task<bool> EnitityExists(int id);
    }
}
