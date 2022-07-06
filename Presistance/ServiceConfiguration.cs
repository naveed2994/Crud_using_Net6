using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Presistance
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddPresistanceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("Db"),
b=>b.MigrationsAssembly("WebApi"));  });
            return services;
        }
    }
}
