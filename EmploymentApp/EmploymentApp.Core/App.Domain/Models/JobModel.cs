using EmploymentApp.Contracts.CommonObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmploymentApp.Domain.Models
{
    [Table("Job", Schema = "dbo")]
    public class JobModel : BaseModel<int>
    {
        [Required]
        [MaxLength(Configurations.MEDIUM_LINE_MAX_LENGTH)]
        public string Name { set; get; }
        [Required]
        [MaxLength(Configurations.BIG_LINE_MAX_LENGTH)]
        public string Description { set; get; }
        public DateTime ValidityDurationTo { set; get; }

        public DateTime ValidityDurationFrom { set; get; }
        public int MaximumApplications { set; get; }
        [Required]
        [MaxLength(Configurations.SINGLE_LINE_MAX_LENGTH)]
        public string Category { get; set; }
        [Required]
        [MaxLength(Configurations.BIG_LINE_MAX_LENGTH)]
        public string Skills { get; set; }
        [Required]
        [MaxLength(Configurations.BIG_LINE_MAX_LENGTH)]
        public string Responsibilities { get; set; }

    }
}
