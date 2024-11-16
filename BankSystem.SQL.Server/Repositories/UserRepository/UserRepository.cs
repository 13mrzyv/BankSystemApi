using BankSystem.Domain.Entities;
using BankSystem.Repository.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.SQL.Server.Repositories.UserRepository
{
    public class UserRepository : BaseSqlRepository, IUserRepository
    {
        public UserRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var conn = await OpenSqlConnectionAsync();

            var users = await conn.QueryAsync<User>("select * from Users");

            await conn.CloseAsync();

            return users;
        }
    }
}
