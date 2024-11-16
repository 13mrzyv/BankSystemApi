using BankSystem.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
    }
}
