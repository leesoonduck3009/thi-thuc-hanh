using WebApiProject.Entities.Identity;

namespace WebApiProject.Services.Interface
{
    public interface IJwtService
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);

    }
}
