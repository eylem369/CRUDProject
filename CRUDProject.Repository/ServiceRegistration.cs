using CRUDProject.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRUDProject.Repository
{
    public static class ServiceRegistration
    {
        public static void AddRepository(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("mssql"));
            });
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
