using BankSystem.Domain.Dtos.UserRequests;
using BankSystem.Domain.Entities;
using BankSystem.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Repository.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserById(int userId);
        Task<bool> InsertUser(UserInsertRequest request);  //
        Task<User> DeleteUserById(int userId);
        Task<bool> UpdateUserById(User user);

    }
}
