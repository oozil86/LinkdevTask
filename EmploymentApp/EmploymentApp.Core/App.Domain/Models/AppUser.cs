using Microsoft.AspNetCore.Identity;

namespace EmploymentApp.Domain.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { set; get; }
        public string Lastname { set; get; }
        public string ProfilePicture { set; get; }

    } 
}
