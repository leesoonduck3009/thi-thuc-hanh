using TestWebApplication.Services.Interface;

namespace TestWebApplication.Services
{
    public static class ServicesRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
