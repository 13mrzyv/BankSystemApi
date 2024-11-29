using BankSystem.Domain.Dtos.UserRequests;
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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<User> GetUserById(int userId)
        {
            var user = await _unitOfWork.UserRepository.GetUserById(userId);
            if (user == null)
            {
                return null;
            }
            else
            {
                return user;
            }
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var users = await _unitOfWork.UserRepository.GetUsersAsync();

            if (users == null)
            {
                return null;
            }

            return users;
        }
        public async Task<bool> InsertUser(UserInsertRequest request)  //
        {
            var result = await _unitOfWork.UserRepository.InsertUser(request);
            return result;
        }
        public async Task<User> DeleteUserById(int userId)
        {
            var user = await _unitOfWork.UserRepository.DeleteUserById(userId);
            if (user == null)
            {
                return null;
            }
            else
            {
                return user;
            }
        }
        public async Task<bool> UpdateUserById(User user)
        {
            var result = await _unitOfWork.UserRepository.UpdateUserById(user);
            return result;
        }
        
    }
}