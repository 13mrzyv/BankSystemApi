using Azure.Core;
using BankSystem.Application.Services;
using BankSystem.Domain.Dtos;
using BankSystem.Domain.Dtos.UserRequests;
using BankSystem.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankSystemApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<bool> CreateUser(CustomerRegistration _user)
        {
            var user1 = await _authService.CreateUser(_user);
            return user1;
        }
    }
}
