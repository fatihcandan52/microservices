using Microservices.CatalogAPI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.CatalogAPI.Extensions
{
    public static class ServicesCollectionServices
    {
        public static IServiceCollection AddRegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICourseService, CourseManager>();

            return services;
        }
    }
}
