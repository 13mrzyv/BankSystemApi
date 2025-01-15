using BankSystem.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Application.Services
{
    public class TokenService(IConfiguration _configuration):ITokenService
    {
        public async Task<string> GenerateTokenAsync(string UserName)
        {
            var jwtKey = _configuration["JwtSettings:JwtKey"];
            if (string.IsNullOrEmpty(jwtKey))
            {
                throw new InvalidOperationException("JWT anahtarı (Security:jwtKey) yapılandırmada eksik veya boş.");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            IEnumerable<Claim> claims = new Claim[] { new Claim(ClaimTypes.Name, UserName) };

            var token = new JwtSecurityToken(
                _configuration["JwtSettings:Issuer"], // Issuer
                _configuration["JwtSettings:Audience"], // Audience
                expires: DateTime.UtcNow.AddMinutes(30), // Token süresi
                claims: claims,
                signingCredentials: credentials
            );

            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
