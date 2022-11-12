using EmploymentApp.Contracts.BusinessObjects;
using EmploymentApp.Contracts.CommonObjects;
using EmploymentApp.Services.Abstractions.IServicesManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Linkdev_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [EnableCors(CorsOrigin.LOCAL_ORIGIN)]
    public class JobController : ControllerBase
    {
        private readonly IEmploymentServiceManager _service;
        public JobController(IEmploymentServiceManager service)
        {
            _service = service;
        }
        
        [HttpPost(nameof(InsertNewJob))]
        [Produces("application/json", Type = typeof(CommonResponse<string>))]
        public async Task<IActionResult> InsertNewJob(JobCreateDto Job)
           => Ok(await _service.JobService.InsertNewJob(Job));
       
        [HttpPut(nameof(UpateJob))]
        [Produces("application/json", Type = typeof(CommonResponse<string>))]
        public async Task<IActionResult> UpateJob(JobDto Job)
          => Ok(await _service.JobService.UpdateJob(Job));

        [HttpDelete(nameof(DeleteJob))]
        [Produces("application/json", Type = typeof(CommonResponse<string>))]
        public async Task<IActionResult> DeleteJob(int Id)
          => Ok(await _service.JobService.DeleteJob(Id));

        [HttpPost(nameof(GetPagedJobs))]
        [Produces("application/json", Type = typeof(CommonResponse<PagedEntity<JobDto>>))]
        public async Task<IActionResult> GetPagedJobs(PagationFilter filter)
          => Ok(await _service.JobService.GetFilteredJobs(filter));

    }
}
