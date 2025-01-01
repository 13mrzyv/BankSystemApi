using Amazon.Runtime.Internal;
using Azure.Core;
using BankSystem.Application.Services;
using BankSystem.Domain.Dtos;
using BankSystem.Domain.Dtos.UserRequests;
using BankSystem.Domain.Entities;
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
        private readonly ITokenService _tokenService;
       

        public AuthController(IAuthService authService, ITokenService tokenService)
        {
            _authService = authService;
            _tokenService = tokenService;
   
        }

        [HttpPost]
        public async Task<bool> CreateUser(CustomerRegistration _user)
        {
            var user1 = await _authService.CreateUser(_user);
            return user1;
        }
        [HttpPost]
        public async Task<LoginResponseModel> Login(LoginRequestModel loginRequestModel)
        {
            LoginResponseModel loginResponseModel = new LoginResponseModel();
            if(ModelState.IsValid==false)
            {
                loginResponseModel.sucsess = false;
                loginResponseModel.message = "verilenler tam daxil edilmeyib";
            }
            else
            {
                loginResponseModel = await _authService.Login(loginRequestModel);
                if (loginResponseModel.sucsess)
                {
                    var token = await _tokenService.GenerateTokenAsync(loginRequestModel.GmailAdress);
                    loginResponseModel.token = token;
                }
            }
            return loginResponseModel;
        }
    }
}
