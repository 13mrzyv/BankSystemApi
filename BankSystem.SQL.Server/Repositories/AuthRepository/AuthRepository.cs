using Azure.Core;
using BankSystem.Domain.Dtos;
using BankSystem.Domain.Dtos.UserRequests;
using BankSystem.Domain.Services;
using BankSystem.Repository.Repositories;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BankSystem.SQL.Server.Repositories.AuthRepository
{
    public class AuthRepository : BaseSqlRepository, IAuthRepository
    {
        public AuthRepository(string connectionString) : base(connectionString)
        {
        }

      
        public async Task<bool> CreateUser(CustomerRegistration _user)
        {
            var conn = await OpenSqlConnectionAsync();
            var InsertedColumbs = await conn.ExecuteAsync($"INSERT INTO CustomerRegistration (UserId,Name,SurName,DateOfBirth,Gender,GmailAdress,Password,Number) VALUES (@userid,@name,@surname,@dateofbirth,@gender,@gmailadress,@password,@number)", new { userid = _user.UserId, name = _user.Name, surname = _user.surName, dateofbirth = _user.DateOfBirth, gender = _user.Gender, gmailadress = _user.GamailAdress, password = _user.Password, number = _user.Number });
            await conn.CloseAsync();
            return InsertedColumbs != 0;
        }

        public async Task<LoginResponseModel> Login(LoginRequestModel loginRequestModel)
        {
            LoginResponseModel loginResponseModel = new LoginResponseModel();
            var conn = await OpenSqlConnectionAsync();
            var intresult = conn.QueryFirstAsync<int>($"SELECT COUNT(1) FROM CustomerRegistration WHERE GmailAdress = @gmailadress AND Password = @password", new { gmailadress = loginRequestModel.GmailAdress, password = loginRequestModel.Password });
            if (await intresult == 1) 
            {
                await conn.CloseAsync();
                loginResponseModel.sucsess = true;
                loginResponseModel.message = "Giris edildi...";
            }
            else 
            {
                await conn.CloseAsync();
                loginResponseModel.sucsess = false;
                loginResponseModel.message = "Duzgun giris edin...";
            }
            return loginResponseModel;
        }
    }
}
