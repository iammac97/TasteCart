using AutoMapper.Internal.Mappers;
using TasteCart.Services.AuthAPI.Models.Dto;

namespace TasteCart.Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<string>Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<bool> AssignRole(string email, string roleName);
    }
}
