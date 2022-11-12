using EmploymentApp.Contracts.BusinessObjects;
using Microsoft.AspNetCore.Identity;

namespace EmploymentApp.Services.Abstractions.IServices
{
    public interface IIdentityService
    {
        public Task<LoginResponseDto> Login(LoginRequestDto model);
        public Task<IdentityResult> Register(RegisterRequestDto register);
    }
}
