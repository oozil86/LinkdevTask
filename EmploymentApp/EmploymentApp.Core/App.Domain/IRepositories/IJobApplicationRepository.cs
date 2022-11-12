using EmploymentApp.Domain.IGeneralRepositories;
using EmploymentApp.Domain.Models;

namespace EmploymentApp.Domain.IRepositories
{
    public interface IJobApplicationRepository : IGenericRepository<JobApplicationModel, int>
    {

    }
}
