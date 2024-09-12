using LunaTask.DAL.ApplicationDbContext;
using LunaTask.DAL.GenericRepository;
using LunaTask.DAL.GenericRepository.Interfaces;
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
            });
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();

            return services;
        }

        public static void InitDb(this IServiceProvider service)
        {
            using var scope = service.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.EnsureCreated();
        }

    }
}
