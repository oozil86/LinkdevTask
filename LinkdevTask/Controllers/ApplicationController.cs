using EmploymentApp.Contracts.BusinessObjects;
using EmploymentApp.Contracts.CommonObjects;
using EmploymentApp.Services.Abstractions.IServicesManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Linkdev_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IEmploymentServiceManager _service;
        public ApplicationController(IEmploymentServiceManager service)
        {
            _service = service;
        }

        [HttpPost(nameof(ApplyToJob))]
        [Produces("application/json", Type = typeof(CommonResponse<string>))]
        public async Task<IActionResult> ApplyToJob(JobApplicationDto JobApplication)
           => Ok(await _service.ApplicantService.ApplyToJob(JobApplication));
    }
}
