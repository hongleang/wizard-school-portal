namespace SchoolPortalApi.Core.Interfaces.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<TResult>> GetAllAsync<TResult>();
        Task<TResult?> GetAsync<TResult>(int? id);
        Task AddAsync<TSource, TResult>(TSource entity);
        Task<bool> UpdateAsync<TSource>(int id, TSource entity);
        Task<bool> DeleteAsync(int id);
    }
}
