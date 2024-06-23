using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;
using TasteCart.Service.AuthAPI.Models.Dto;
using TasteCart.Service.AuthAPI.Service.IService;
using TasteCart.Services.AuthAPI.Data;
using TasteCart.Services.AuthAPI.Models;

namespace TasteCart.Service.AuthAPI.Service
{
    public class AuthService : IAuthService

    {
        private readonly AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthService(AppDbContext db,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
           var user=_db.ApplicationUsers.FirstOrDefault(u=>u.UserName.ToLower()==loginRequestDto.UserName.ToLower());
            bool isValid=await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
            if (user == null || isValid == false)
            {
                return new LoginResponseDto() { User = null, Token = "" };
            }
            //if user found,Generate JWT token
            UserDto userDto = new()
            {
                Email = user.Email,
                ID = user.Id,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber
            };
            LoginResponseDto loginResponseDto = new LoginResponseDto()
            {
                User = userDto,
                Token = ""

            };
            return loginResponseDto;

        }

        public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
        {
            ApplicationUser user = new()
            {
                UserName =registrationRequestDto.Email,
                Email=registrationRequestDto.Email,
                NormalizedEmail=registrationRequestDto.Email,
                Name=registrationRequestDto.Name,
                PhoneNumber=registrationRequestDto.PhoneNumber
            };
            try
            {
                var result=await _userManager.CreateAsync(user,registrationRequestDto.Password);
                if (result.Succeeded)
                {
                    var userToReturn = _db.ApplicationUsers.First(u => u.UserName == registrationRequestDto.Email);
                    UserDto userDto = new()
                    {
                        Email=userToReturn.Email,
                        ID=userToReturn.Id,
                        Name=userToReturn.Name,
                        PhoneNumber=userToReturn.PhoneNumber
                    };
                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }


            }
            catch (Exception)
            {

            }
            return "Error Encountered";
        }

    }
}
