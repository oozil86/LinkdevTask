using EmploymentApp.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmploymentApp.Persistence.Context
{
    public class EmploymentContext : IdentityDbContext<AppUser, ApplicationRole, string>
    {
        public EmploymentContext(DbContextOptions<EmploymentContext> options)
          : base(options)
        {
        }
        public virtual DbSet<JobApplicationModel> JobApplications { get; set; }
        public virtual DbSet<JobApplicantModel> JobApplicant { get; set; }
        public virtual DbSet<JobModel> Jobs { get; set; }
    }
}
