using EmploymentApp.Contracts.CommonObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentApp.Domain.Models
{
    [Table("JobApplicant", Schema = "dbo")]
    public class JobApplicantModel : BaseModel<int>
    {
        [Required]
        [MaxLength(Configurations.SINGLE_LINE_MAX_LENGTH)]
        public string Name { set; get; }
        [Required]
        [MaxLength(Configurations.SINGLE_LINE_MAX_LENGTH)]
        public string Email { set; get; }
        [Required]
        [MaxLength(Configurations.SINGLE_LINE_MAX_LENGTH)]
        public string MobileNumber { set; get; }
    }
}
