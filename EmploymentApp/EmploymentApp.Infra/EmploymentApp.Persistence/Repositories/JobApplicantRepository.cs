using EmploymentApp.Domain.IRepositories;
using EmploymentApp.Persistence.Context;
using EmploymentApp.Persistence.GeneralRepository;
using EmploymentApp.Domain.Models;

namespace EmploymentApp.Persistence.Repositories
{
    public class JobApplicantRepository : GenericRepository<JobApplicantModel, int>, IJobApplicantRepository
    {
        private readonly EmploymentContext _context;
        public JobApplicantRepository(EmploymentContext context) : base(context)
        {
            _context = context;
        }

    }
}
