using EmploymentApp.Domain.IMapping;
using EmploymentApp.Domain.IUnitofWork;
using EmploymentApp.Services.Abstractions.IServices;
using EmploymentApp.Services.Abstractions.IServicesManager;
using EmploymentApp.Services.Services;
using Microsoft.Extensions.Configuration;

namespace EmploymentApp.Persentation.ServicesManager
{
    public class EmploymentServiceManager : IEmploymentServiceManager
    {
        private readonly IUnitofwork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly ITypeMapper _mapper;
        public EmploymentServiceManager(IUnitofwork unitOfWork, IConfiguration configuration, ITypeMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
        }

        private IJobService _jobService;
        private IApplicantService _applicantService;

        public IJobService JobService =>
       _jobService ??= new JobService(_unitOfWork, _configuration, _mapper);
        public IApplicantService ApplicantService =>
       _applicantService ??= new ApplicantService(_unitOfWork, _configuration, _mapper);
    }
}
