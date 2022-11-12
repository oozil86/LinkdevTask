using EmploymentApp.Contracts.CommonObjects;

namespace EmploymentApp.Contracts.BusinessObjects
{
    public class JobApplicationDto 
    {
        public int JobId { get; set; }
        public JobApplicantDto Applicant { get; set; }
    }
}
