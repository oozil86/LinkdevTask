using EmploymentApp.Contracts.BusinessObjects;
using EmploymentApp.Contracts.CommonObjects;

namespace EmploymentApp.Services.Abstractions.IServices
{
    public interface IApplicantService
    {
        public Task<CommonResponse<string>> ApplyToJob(JobApplicationDto application);
    }
}
