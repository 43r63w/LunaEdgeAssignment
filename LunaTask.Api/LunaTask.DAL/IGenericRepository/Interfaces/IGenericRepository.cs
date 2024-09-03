using System.Linq.Expressions;

namespace LunaTask.DAL.IGenericRepository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeOptions = null);

        Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, string? includeOptions = null);

        Task SaveChangesAsync();
    }
}
