using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LunaTask.DAL.IGenericRepository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);

        Task<T> DeleteAsync(T entity);

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeOptions = null);

        Task<T> GetByIdAsync(Expression<Func<T, bool>>? filter = null, string? includeOptions = null);
    }
}
