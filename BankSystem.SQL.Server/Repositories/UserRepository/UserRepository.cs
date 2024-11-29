using Azure.Core;
using BankSystem.Domain.Dtos.UserRequests;
using BankSystem.Domain.Entities;
using BankSystem.Domain.Services;
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

        public async Task<User> DeleteUserById(int userId)
        {
            var conn = await OpenSqlConnectionAsync();
            var user = await conn.QueryFirstOrDefaultAsync<User>($"delete from Users where UserId={userId}");
            await conn.CloseAsync();
            return user;
        }
        public async Task<User> GetUserById(int userId)
        {
            var conn = await OpenSqlConnectionAsync();
            var user = await conn.QueryFirstOrDefaultAsync<User>($"select* from Users where UserId={userId}");
            await conn.CloseAsync();
            return user;
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var conn = await OpenSqlConnectionAsync();

            var users = await conn.QueryAsync<User>("select * from Users");

            await conn.CloseAsync();

            return users;
        }
        public async Task<bool> UpdateUserById(User user)
        {
            var conn= await OpenSqlConnectionAsync();
            var InsertedColumbs= await conn.ExecuteAsync($"update Users set Name=@name,Surname=@surname,GmailAdress=@gmailadress,Password=@password,Number=@number where UserId=@userId",new {userId=user.UserId, name = user.Name, surname = user.Surname, gmailadress=user.GmailAdress, password=user.Password, number=user.Number});
            await conn.CloseAsync();
            return InsertedColumbs != 0;
        }
        public async Task<bool> InsertUser(UserInsertRequest request) 
        {
            var conn = await OpenSqlConnectionAsync();
            var InsertedColumbs = await conn.ExecuteAsync($"INSERT INTO Users (UserId,Name,Surname,IsDeleted,GmailAdress,Password,Number,PrizesBonus) VALUES (@userid,@name,@surname,0,@gmailadress,@password,@number,0)", new {userid=request.UsertId, name = request.Name, surname = request.Surname, gmailadress=request.GmailAdress, password=request.Password, number=request.Number});
            await conn.CloseAsync();
            return InsertedColumbs != 0;
        }
    }
}
