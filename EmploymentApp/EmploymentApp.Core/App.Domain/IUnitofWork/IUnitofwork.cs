using EmploymentApp.Domain.IRepositories;

namespace EmploymentApp.Domain.IUnitofWork
{
    public interface IUnitofwork
    {
        IIdentityRepository IdentityRepository { get; }
        IJobApplicantRepository JobApplicantRepository { get; }
        IJobApplicationRepository JobApplicationRepository { get; }
        IJobRepository JobRepository { get; }
        
        int Save();
        Task<int> SaveAsync();
        void BeginTransaction();

        void Commit();

        void RollBack();
    }
}
