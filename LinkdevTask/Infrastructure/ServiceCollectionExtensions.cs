using EmploymentApp.Persistence.Context;
using EmploymentApp.Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AKILA.Web.Host.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services,
                        IConfiguration configuration)
                        => services.
                            AddDbContext<EmploymentContext>(options =>
                                        options.UseSqlServer(configuration.GetConnectionString("42SolutionTaskConectionString")));

        public static IdentityBuilder AddIdentity(this IServiceCollection services)
            => services
            .AddIdentity<AppUser, ApplicationRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
        .AddDefaultTokenProviders()
        .AddEntityFrameworkStores<EmploymentContext>();

        public static AuthenticationBuilder AddJwtAuthentication(
                 this IServiceCollection services,
                      IConfiguration configuration)
        {
            var key = Encoding.ASCII
                     .GetBytes(configuration
                                 .GetSection("ApplicationSettings")
                                 .GetSection("Secret").Value);
            return services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }

    }
}
