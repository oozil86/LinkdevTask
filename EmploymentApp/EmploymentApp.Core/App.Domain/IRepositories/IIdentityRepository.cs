using EmploymentApp.Contracts.BusinessObjects;
using Microsoft.AspNetCore.Identity;

namespace EmploymentApp.Domain.IRepositories
{
    public interface IIdentityRepository
    {
        Task<LoginResponse> Login(LoginRequestDto model);
        Task<IdentityResult> Register(RegisterRequestDto register);
    }
}
