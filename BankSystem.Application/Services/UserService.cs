using BankSystem.Domain.Entities;
using BankSystem.Domain.Services;
using BankSystem.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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


    }
}
