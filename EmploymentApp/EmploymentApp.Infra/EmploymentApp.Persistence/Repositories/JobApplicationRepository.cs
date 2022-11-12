using EmploymentApp.Domain.IRepositories;
using EmploymentApp.Persistence.Context;
using EmploymentApp.Persistence.GeneralRepository;
using EmploymentApp.Domain.Models;

namespace EmploymentApp.Persistence.Repositories
{
    public class JobApplicationRepository : GenericRepository<JobApplicationModel, int>, IJobApplicationRepository
    {
        private readonly EmploymentContext _context;
        public JobApplicationRepository(EmploymentContext context):base(context)
        {
           _context = context;
        }

    }
}
