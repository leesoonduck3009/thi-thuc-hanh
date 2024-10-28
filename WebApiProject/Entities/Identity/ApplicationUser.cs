using Microsoft.AspNetCore.Identity;

namespace WebApiProject.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
