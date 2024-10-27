using TestWebApplication.Repositories.Interface;

namespace TestWebApplication.Repositories
{
    public static class RepositoryRegisteration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services
            .AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>))
            .AddScoped<IRepositoryFactory, RepositoryFactory>();
        }
    }
}
