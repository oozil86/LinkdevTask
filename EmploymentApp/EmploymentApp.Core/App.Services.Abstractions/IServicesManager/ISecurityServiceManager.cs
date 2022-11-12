using EmploymentApp.Services.Abstractions.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentApp.Services.Abstractions.IServicesManager
{
    public interface ISecurityServiceManager
    {
        public IIdentityService IdentityService { get; }
    }
}
