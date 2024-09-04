using LunaTask.DAL.ApplicationDbContext;
using LunaTask.DAL.IGenericRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace LunaTask.DAL.IGenericRepository
{
    public class TaskRepository : GenericRepository<Entities.Task>, ITaskRepository
    {
        public TaskRepository(AppDbContext dbContext)
            : base(dbContext)
        { }


        public async Task<List<Entities.Task>> SortAsync(
            Expression<Func<Entities.Task, object>> selectorKey,
            int pageNumber,
            int pageSize,
            string sort
           )
        {
            IQueryable<Entities.Task> query = _dbSet;

            query = query.Skip((pageNumber - 1) * pageSize)
                         .Take(pageSize);

            query = sort == "desc"
                ? query.OrderByDescending(selectorKey)
                : query.OrderBy(selectorKey);



            return await query.ToListAsync();
        }


    }
}
