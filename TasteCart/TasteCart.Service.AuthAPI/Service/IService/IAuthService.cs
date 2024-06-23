using TasteCart.Service.AuthAPI.Models.Dto;

namespace TasteCart.Service.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<string>Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
    }
}
