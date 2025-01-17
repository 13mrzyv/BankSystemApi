using Azure.Core;
using BankSystem.Domain.Dtos.UserRequests;
using BankSystem.Domain.Entities;
using BankSystem.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace BankSystemApi.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IEnumerable> GetUsersAsync()
        {
            var users = await _userService.GetUsersAsync();
            return users;
        }

        [HttpGet]
        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> GetUserById(int userId)
        {
            var user = await _userService.GetUserById(userId);
            return Ok(user);
        }
        [HttpPost]
        public async Task<bool> InsertUser(UserInsertRequest request) //
        {
            var user = await _userService.InsertUser(request);
            return user;
        }
        [HttpDelete]
        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> DeleteUserById(int userId)
        {
            var user = await _userService.DeleteUserById(userId);
            return Ok(user);
        }
        [HttpPut]
        public async Task<bool> UpdateUserById(User user)
        {
            var user1 = await _userService.UpdateUserById(user);
            return user1;
        }
    }
}
