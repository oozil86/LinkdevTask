using EmploymentApp.Domain.IMapping;
using EmploymentApp.Domain.IUnitofWork;
using EmploymentApp.Persentation.ServicesManager;
using EmploymentApp.Persentation.UnitofWork;
using EmploymentApp.Persistence.Mapping;
using EmploymentApp.Services.Abstractions.IServicesManager;

namespace AKILA.Web.Host.Infrastructure
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
            => services
               .AddScoped<IUnitofwork, UnitofWork>()
               .AddScoped<ISecurityServiceManager, SecurityServiceManager>()
               .AddScoped<IEmploymentServiceManager, EmploymentServiceManager>()
               .AddScoped<ITypeMapper, TypeMapper>();
    }
}
