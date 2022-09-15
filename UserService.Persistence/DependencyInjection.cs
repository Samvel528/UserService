using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserService.Application.Interfaces;

namespace UserService.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<UserServiceDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IUserServiceDbContext>(provider =>
                provider.GetService<UserServiceDbContext>());

            return services;
        }
    }
}
