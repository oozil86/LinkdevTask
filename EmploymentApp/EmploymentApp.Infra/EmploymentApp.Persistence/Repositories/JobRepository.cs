using EmploymentApp.Domain.IRepositories;
using EmploymentApp.Persistence.Context;
using EmploymentApp.Persistence.GeneralRepository;
using EmploymentApp.Domain.Models;
using EmploymentApp.Contracts.BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace EmploymentApp.Persistence.Repositories
{
    public class JobRepository : GenericRepository<JobModel, int>, IJobRepository
    {
        private readonly EmploymentContext _context;
        public JobRepository(EmploymentContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedEntity<JobDto>> GetFilteredJobtData(PagationFilter filter)
        {
            var query = _context.Jobs
                  .AsQueryable();

            if (filter.Columns != null)
            {
                foreach (var entityfilter in filter.Columns)
                {
                    if (entityfilter.Name == "Name")
                    {
                        if (!string.IsNullOrEmpty(entityfilter.Value))
                        {
                            if (entityfilter.MatchMode == "startsWith")
                                query = query.Where(c => c.Name.StartsWith(entityfilter.Value));
                            else if (entityfilter.MatchMode == "contains")
                                query = query.Where(c => c.Name.Contains(entityfilter.Value));
                            else if (entityfilter.MatchMode == "notContains")
                                query = query.Where(c => !c.Name.Contains(entityfilter.Value));
                            else if (entityfilter.MatchMode == "endsWith")
                                query = query.Where(c => c.Name.EndsWith(entityfilter.Value));
                            else if (entityfilter.MatchMode == "equals")
                                query = query.Where(c => c.Name.Equals(entityfilter.Value));
                            else if (entityfilter.MatchMode == "notEquals")
                                query = query.Where(c => !c.Name.Equals(entityfilter.Value));
                        }
                    }
                }
            }
            if (filter.SortOrder == -1)
            {

                if (filter.SortField == "name")
                    query = query.OrderByDescending(c => c.Name);
            }
            else
            {

                if (filter.SortField == "name")
                    query = query.OrderBy(c => c.Name);
            }

            var totalItemsCount = query.Count();

            var res = await query.
                Skip(filter.Start).
                Take(filter.Rows).
                AsNoTracking().
                Select(c => new JobDto
                {
                    Id=c.Id,
                    Category = c.Category,
                    Description = c.Description,
                    MaximumApplications = c.MaximumApplications,
                    Name = c.Name,
                    Responsibilities = c.Responsibilities,
                    Skills = c.Skills,
                    ValidityDurationFrom = c.ValidityDurationFrom.ToString("dd/MM/yyyy"),
                    ValidityDurationTo = c.ValidityDurationTo.ToString("dd/MM/yyyy")
                }).ToListAsync();

            return new PagedEntity<JobDto>(res, totalItemsCount);
        }

        public async Task UpdateJob(JobModel Job)
        {
            var job = await _context.Jobs.FindAsync(Job.Id);
            if (job != null)
            {
                job.Name = Job.Name;
                job.Description = Job.Description;
                job.ValidityDurationFrom = Job.ValidityDurationFrom;
                job.ValidityDurationTo = Job.ValidityDurationTo;
                job.MaximumApplications = Job.MaximumApplications;
                job.Category = Job.Category;
                job.Responsibilities = Job.Responsibilities;
                job.Skills = Job.Skills;
            }
        }
    }
}
