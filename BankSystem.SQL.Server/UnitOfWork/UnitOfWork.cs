using BankSystem.Domain.Services;
using BankSystem.Repository.Repositories;
using BankSystem.Repository.UnitOfWork;
using BankSystem.SQL.Server.Repositories;
using BankSystem.SQL.Server.Repositories.AuthRepository;
using BankSystem.SQL.Server.Repositories.PrizeRepository;
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
        private PrizeRepository _prizeRepository;
        private AuthRepository _authRepository;
        private IConfiguration configuration;
        public UnitOfWork(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("BankSystemConnectionString");
        }

        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_connectionString);
        
        public IPrizeRepository PrizeRepository => _prizeRepository ??= new PrizeRepository(_connectionString);
        public IAuthRepository AuthRepository => _authRepository ??= new AuthRepository(_connectionString);
    }
    
}
