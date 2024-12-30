using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Domain.Services
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAsync(string username);
    }
}
