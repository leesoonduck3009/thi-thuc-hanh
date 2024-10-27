using Microsoft.EntityFrameworkCore;

namespace TestWebApplication.Data
{
    public static class EntityFrameworkRegisteration
    {
        public static WebApplicationBuilder AddEntityFramewordCore(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            return builder;
        }
    }
}
