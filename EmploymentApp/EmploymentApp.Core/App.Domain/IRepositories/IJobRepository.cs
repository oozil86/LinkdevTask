using EmploymentApp.Contracts.BusinessObjects;
using EmploymentApp.Domain.IGeneralRepositories;
using EmploymentApp.Domain.Models;

namespace EmploymentApp.Domain.IRepositories
{
    public interface IJobRepository : IGenericRepository<JobModel, int>
    {
        public Task UpdateJob(JobModel job);
        public Task<PagedEntity<JobDto>> GetFilteredJobtData(PagationFilter filter);
    }
}
