using EmploymentApp.Domain.IRepositories;
using EmploymentApp.Domain.IUnitofWork;
using EmploymentApp.Persistence.Context;
using EmploymentApp.Persistence.Repositories;
using EmploymentApp.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System.Data.Entity;

namespace EmploymentApp.Persentation.UnitofWork
{
    public class UnitofWork : IUnitofwork
    {
        private readonly EmploymentContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private DbContextTransaction _dbContextTransaction;

        public UnitofWork(EmploymentContext context, RoleManager<ApplicationRole> roleManager,
                                UserManager<AppUser> userManager)
        {         
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

   
        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void BeginTransaction()
        {
            _dbContextTransaction = (DbContextTransaction)_context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _context.SaveChanges();
            _dbContextTransaction?.Commit();
        }

        public void RollBack()
        {
            _dbContextTransaction?.Rollback();
        }

        private IIdentityRepository _identityRepository;
        private IJobApplicantRepository _jobApplicantRepository;
        private IJobApplicationRepository _jobApplicationRepository;
        private IJobRepository _jobRepository;
        public IIdentityRepository IdentityRepository =>
          _identityRepository ??= new IdentityRepository(_roleManager, _userManager, _context);
        public IJobApplicantRepository JobApplicantRepository =>
          _jobApplicantRepository ??= new JobApplicantRepository(_context);
        public IJobApplicationRepository JobApplicationRepository =>
          _jobApplicationRepository ??= new JobApplicationRepository(_context);
        public IJobRepository JobRepository =>
         _jobRepository ??= new JobRepository(_context);
    }
}
