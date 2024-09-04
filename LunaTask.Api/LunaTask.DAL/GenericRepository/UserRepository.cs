using LunaTask.DAL.ApplicationDbContext;
using LunaTask.DAL.Entities;
using LunaTask.DAL.GenericRepository.Interfaces;
using LunaTask.DAL.IGenericRepository;

namespace LunaTask.DAL.GenericRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
