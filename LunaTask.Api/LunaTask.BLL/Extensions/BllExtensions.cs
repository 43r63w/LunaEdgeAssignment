using LunaTask.BLL.Implementations;
using LunaTask.BLL.IServices;
using LunaTask.BLL.Jwt;
using LunaTask.BLL.Jwt.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LunaTask.BLL.Extensions
{
    public static class BllExtensions
    {
        public static IServiceCollection AddJwt(this IServiceCollection services)
        {
            return services.AddScoped<IJwtGenerator, JwtGenerator>();
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITaskService, TaskService>();
            return services;
        }
       

    }
}
