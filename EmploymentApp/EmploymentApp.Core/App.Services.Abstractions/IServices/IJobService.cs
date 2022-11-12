using EmploymentApp.Contracts.BusinessObjects;
using EmploymentApp.Contracts.CommonObjects;

namespace EmploymentApp.Services.Abstractions.IServices
{
    public interface IJobService 
    {
        public Task<CommonResponse<string>> InsertNewJob(JobCreateDto Job);
        public Task<CommonResponse<string>> UpdateJob(JobDto Job);
        public Task<CommonResponse<string>> DeleteJob(int Id);
        public Task<CommonResponse<PagedEntity<JobDto>>> GetFilteredJobs(PagationFilter filter);
    }
}
