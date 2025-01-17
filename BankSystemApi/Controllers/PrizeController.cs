using BankSystem.Domain.Services;
using BankSystem.Repository.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using BankSystem.Application.Services;
using BankSystem.Domain.Entities;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;

namespace BankSystemApi.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PrizeController : ControllerBase
    {
        private readonly IPrizeService _prizeService;
        public PrizeController(IPrizeService prizeService)
        {
            _prizeService = prizeService;
        }
        [HttpGet]
        public async Task<IEnumerable> GetPrizes()
        {
            var prizes = await _prizeService.GetPrizes();
            return prizes;
        }
        [HttpGet]
        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> GetPrizeById(int prizeId)
        {
            var prize = await _prizeService.GetPrizeById(prizeId);
            return Ok(prize);
        }

        [HttpDelete]
        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> DeletePrizeById(int prizeId)
        {
            var prize = await _prizeService.DeletePrizeById(prizeId);
            return Ok(prize);
        }

        [HttpPost]
        public async Task<bool> InsertPrize(Prize prize)
        {
            var prize1 = await _prizeService.InsertPrize(prize);
            return prize1;
        }
        [HttpPut]
        public async Task<bool> UpdatePrize(Prize prize)
        {
            var prize1 = await _prizeService.UpdatePrize(prize);
            return prize1;
        }

    }
}
