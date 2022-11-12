using EmploymentApp.Services.Abstractions.IServices;

namespace EmploymentApp.Services.Abstractions.IServicesManager
{
    public interface IEmploymentServiceManager
    {
        public IJobService JobService { get; }
        public IApplicantService ApplicantService { get; }
    }
}
