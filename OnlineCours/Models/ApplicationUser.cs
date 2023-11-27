using Microsoft.AspNetCore.Identity;

namespace OnlineCours.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
