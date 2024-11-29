using BankSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Domain.Services
{
    public interface IPrizeService
    {
        Task<IEnumerable<Prize>> GetPrizes();
        Task<Prize> GetPrizeById(int prizeId);
        Task<Prize> DeletePrizeById(int prizeId);
        Task<bool> InsertPrize(Prize prize);
        Task<bool> UpdatePrize(Prize prize);
    }
}
