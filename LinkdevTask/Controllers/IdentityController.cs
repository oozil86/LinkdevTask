using EmploymentApp.Contracts.BusinessObjects;
using EmploymentApp.Services.Abstractions;
using EmploymentApp.Services.Abstractions.IServicesManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Linkdev_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly ISecurityServiceManager _service;
        public IdentityController(ISecurityServiceManager service)
        {
            _service = service;
        }

        [HttpPost(nameof(Register))]
        [Produces("application/json", Type = typeof(IdentityResult))]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Register(RegisterRequestDto register)
            => Ok(await _service.IdentityService.Register(register));

        [HttpPost(nameof(Login))]
        [Produces("application/json", Type = typeof(LoginResponseDto))]
        public async Task<IActionResult> Login(LoginRequestDto model)
            => Ok(await _service.IdentityService.Login(model));
    }
}
