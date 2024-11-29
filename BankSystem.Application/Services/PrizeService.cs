using BankSystem.Domain.Entities;
using BankSystem.Domain.Services;
using BankSystem.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankSystem.Application.Services
{
    public class PrizeService : IPrizeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PrizeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Prize> DeletePrizeById(int prizeId)
        {
            var prize=await _unitOfWork.PrizeRepository.DeletePrizeById(prizeId);
            return prize;
        }

        public async Task<Prize> GetPrizeById(int prizeId)
        {
            var prize = await _unitOfWork.PrizeRepository.GetPrizeById(prizeId);
            if (prize == null)
            {
                return null;
            }
            else
            {
                return prize;
            }
        }

        public async Task<IEnumerable<Prize>> GetPrizes()
        {
            var prizes = await _unitOfWork.PrizeRepository.GetPrizes();
            if (prizes == null)
            {
                return null;
            }
            return prizes;
        }

        public async Task<bool> InsertPrize(Prize prize)
        {
            var prize1 = await _unitOfWork.PrizeRepository.InsertPrize(prize);
            return prize != null;
        }

        public async Task<bool> UpdatePrize(Prize prize)
        {
            var prize1 = await _unitOfWork.PrizeRepository.UpdatePrize(prize);
            return prize1 != null;
        }
    }
}
