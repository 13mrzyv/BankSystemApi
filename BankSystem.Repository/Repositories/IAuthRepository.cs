using BankSystem.Domain.Dtos.UserRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Repository.Repositories
{
    public interface IAuthRepository
    {
        Task<bool> CreateUser(CustomerRegistration _user);
    }
}
