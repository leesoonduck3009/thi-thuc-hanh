using TestWebApplication.Services.Interface;
using WebApiProject.Services;
using WebApiProject.Services.Interface;

namespace TestWebApplication.Services
{
    public static class ServicesRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
