using TasteCart.Services.AuthAPI.Models;

namespace TasteCart.Service.AuthAPI.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser);
    }
}
