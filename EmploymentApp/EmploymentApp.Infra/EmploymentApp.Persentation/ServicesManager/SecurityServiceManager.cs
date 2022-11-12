using EmploymentApp.Domain.IUnitofWork;
using EmploymentApp.Services.Abstractions.IServices;
using EmploymentApp.Services.Abstractions.IServicesManager;
using EmploymentApp.Services.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentApp.Persentation.ServicesManager
{
    public class SecurityServiceManager : ISecurityServiceManager
    {
        private readonly IUnitofwork _unitOfWork;
        private readonly IConfiguration _configuration;
        public SecurityServiceManager(IUnitofwork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        private IIdentityService _identityService;

        public IIdentityService IdentityService =>
       _identityService ??= new IdentityService(_unitOfWork, _configuration);
    }
}
