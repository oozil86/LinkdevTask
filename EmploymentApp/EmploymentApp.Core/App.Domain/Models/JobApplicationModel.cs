using EmploymentApp.Contracts.CommonObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmploymentApp.Domain.Models
{
    [Table("JobApplication", Schema = "dbo")]
    public class JobApplicationModel : BaseModel<int>
    {
        [Required]
        [ForeignKey(nameof(Jobs))]
        public int JobId { get; set; }
        [Required]
        [ForeignKey(nameof(Applicants))]
        public int ApplicantId { get; set; }

        public virtual JobModel Jobs { get; set; }
        public virtual JobApplicantModel Applicants { get; set; }
    }
}
