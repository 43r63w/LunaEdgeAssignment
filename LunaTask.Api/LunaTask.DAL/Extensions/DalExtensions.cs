using LunaTask.DAL.ApplicationDbContext;
using LunaTask.DAL.IGenericRepository;
using LunaTask.DAL.IGenericRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LunaTask.DAL.Extensions
{
    public static class DalExtensions
    {
        public static IServiceCollection AddDb(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseNpgsql(configuration.GetConnectionString("DefaultDbConnection"));
                }
            );
        }

        public static IServiceCollection AddGenericRepository(this IServiceCollection services)
        {
            return services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
