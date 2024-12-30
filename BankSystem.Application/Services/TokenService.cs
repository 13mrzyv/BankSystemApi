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
            // JWT anahtarının olup olmadığını kontrol edin.
            var jwtKey = _configuration["Security:jwtKey"];
            if (string.IsNullOrEmpty(jwtKey))
            {
                throw new InvalidOperationException("JWT anahtarı (Security:jwtKey) yapılandırmada eksik veya boş.");
            }

            // Signing credentials için güvenlik anahtarını oluşturun
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Kullanıcı adını claim olarak ekleyin
            IEnumerable<Claim> claims = new Claim[] { new Claim(ClaimTypes.Name, UserName) };

            // Token oluşturma işlemi
            var token = new JwtSecurityToken(
                _configuration["Security:JwtIssuer"], // Issuer
                _configuration["Security:JwtAudience"], // Audience
                expires: DateTime.UtcNow.AddMinutes(30), // Token süresi
                claims: claims,
                signingCredentials: credentials
            );

            // Token'ı yazdırın
            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }

    }
}
