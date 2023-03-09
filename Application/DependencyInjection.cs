using Application.Common.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Application.DependencyInjection).Assembly));
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IPostService, PostService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ITagService, TagService>();

            return services;
        }
    }
}
