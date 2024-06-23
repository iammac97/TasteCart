using TasteCart.Services.AuthAPI.Models;

namespace TasteCart.Services.AuthAPI.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser);
    }
}
