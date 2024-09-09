using Microsoft.AspNetCore.Identity;

namespace MotoGP_Web_Site.Database.EntityLayer.Concrete
{
	public class AppUser:IdentityUser<int>
    {
        public string? NameSurname { get; set; }
        public string? ImageUrl { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
