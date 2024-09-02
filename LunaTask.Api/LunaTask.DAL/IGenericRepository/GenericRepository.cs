using LunaTask.DAL.ApplicationDbContext;
using LunaTask.DAL.IGenericRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq.Expressions;

namespace LunaTask.DAL.IGenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected AppDbContext _dbContext;
        protected DbSet<T> _dbSet;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }


        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null,
            string? includeOptions = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }


            if (!string.IsNullOrEmpty(includeOptions))
            {
                foreach (var property in includeOptions
                    .Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {

                    query = query.Include(property);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>>? filter = null,
            string? includeOptions = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeOptions))
            {
                foreach (var property in includeOptions
                    .Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {

                    query = query.Include(property);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
        }

        public Task SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }

}
