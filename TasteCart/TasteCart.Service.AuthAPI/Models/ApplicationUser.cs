using Microsoft.AspNetCore.Identity;

namespace TasteCart.Services.AuthAPI.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Name {  get; set; }
    }
}
