using System.Linq.Expressions;

namespace LunaTask.DAL.IGenericRepository.Interfaces
{
    public interface ITaskRepository : IGenericRepository<Entities.Task>
    {
        Task<List<Entities.Task>> SortAsync(
            Expression<Func<Entities.Task, object>> selectorKey,
            string sort = "desc"
        );
    }

}
