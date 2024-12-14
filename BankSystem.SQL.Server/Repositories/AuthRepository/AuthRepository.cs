//using Azure.Core;
//using BankSystem.Domain.Dtos.UserRequests;
//using BankSystem.Repository.Repositories;
//using Dapper;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Mail;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;
//using static System.Runtime.InteropServices.JavaScript.JSType;

//namespace BankSystem.SQL.Server.Repositories.AuthRepository
//{
//    public class AuthRepository : BaseSqlRepository, IAuthRepository
//    {
//        public AuthRepository(string connectionString) : base(connectionString)
//        {
//        }

//        public async Task<bool> CreateUser(CustomerRegistration _user)
//        {
//            var conn = await OpenSqlConnectionAsync();
//            var InsertedColumbs = await conn.ExecuteAsync($"INSERT INTO CustomerRegistration (UserId,Name,SurName,DateOfBirth,Gender,GmailAdress,Password,Number) VALUES (@userid,@name,@surname,@dateofbirth,@gender,@gmailadress,@password,@number)", new { userid = _user.UserId, name = _user.Name, surname = _user.surName, dateofbirth = _user.DateOfBirth, gender = _user.Gender, gmailadress = _user.GamailAdress, password = _user.Password, number = _user.Number });
//            await conn.CloseAsync();
//            return InsertedColumbs != 0;
//        }
//    }
//}
