using CRUDProject.Service.Services.Contract;
using CRUDProject.Service.Services.Implements;
using Microsoft.Extensions.DependencyInjection;

namespace CRUDProject.Service
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<IAppUserService,AppUserService>();
        }
    }
}
