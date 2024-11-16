using BankSystem.Repository.Repositories;
using BankSystem.Repository.UnitOfWork;
using BankSystem.SQL.Server.Repositories;
using BankSystem.SQL.Server.Repositories.UserRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.SQL.Server.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private string _connectionString;
        private UserRepository _userRepository;

        public UnitOfWork(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("BankSystemConnectionString");
        }

        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_connectionString);
    }
}
