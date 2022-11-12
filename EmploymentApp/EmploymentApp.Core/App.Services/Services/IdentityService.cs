using EmploymentApp.Contracts.BusinessObjects;
using EmploymentApp.Domain.IUnitofWork;
using EmploymentApp.Services.Abstractions.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmploymentApp.Services.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IUnitofwork _unitOfWork;
        private readonly IConfiguration _configuration;
        public IdentityService(IUnitofwork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<IdentityResult> Register(RegisterRequestDto register)
        {

            if (register == null)
                return null;
            var result = await _unitOfWork.IdentityRepository.Register(register);

            return result;
        }
        public async Task< LoginResponseDto> Login(LoginRequestDto model)
        {
            var response = await _unitOfWork.IdentityRepository.Login(model);
            if (response == null)
            {
                return new LoginResponseDto { Token = "", Message = "Failed Login" };
            }
            var Secret = _configuration.GetSection("ApplicationSettings").GetSection("Secret").Value;

            return new LoginResponseDto
            {
                Token = GenerateJwtToken(model.Email, Secret, response.Roles),
                Message = "Success Login"
            };
        }
        private string GenerateJwtToken(string Email, string secret, IList<string> userRoles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, Email),
            };
        
            claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return encryptedToken;
        }

    }
}
