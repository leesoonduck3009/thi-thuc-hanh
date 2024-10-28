using Microsoft.EntityFrameworkCore;
using TestWebApplication.Data;
using WebApiProject.Enums;

namespace WebApiProject.Data
{
    public static class SeedingDb
    {
        public static async Task InitUser(ApplicationDbContext context)
        {
            if ((await context.Users.SingleOrDefaultAsync(p => p.Username == "admin")) == null)
            {
                await context.Users.AddAsync(new Entities.User { Username = "admin", Password = "123456", Role = UserRole.Admin.ToString(), Id = new Guid(), IsDeleted = false, Name = "admin" });
                await context.SaveChangesAsync();
            }
        }
    }
}
