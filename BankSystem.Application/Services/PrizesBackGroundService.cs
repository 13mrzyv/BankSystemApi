using BankSystem.SQL.Server.Repositories.PrizeRepository;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace BankSystem.Application.Services
{
    public class PrizesBackGroundService : BackgroundService
    {
        private readonly string _connectionString = "Data Source=DESKTOP-7B66A0I\\SQLEXPRESS;Initial Catalog=BankSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        private readonly PrizeRepository _prizeRepository;

        public PrizesBackGroundService(PrizeRepository prizeRepository)
        {
            _prizeRepository = prizeRepository;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _prizeRepository.SyncTableAsync();
            await Task.Delay(TimeSpan.FromSeconds(20), stoppingToken);
        }
        //private async Task SyncTableAsync()
        //{
        //    try
        //    {
        //        using (var conn = new SqlConnection(_connectionString))
        //        {
        //            await conn.OpenAsync();
        //            string query = @"insert into PrizeWinners(UserId,UserName,Prize,WinDate)
        //                select u.UserId,u.Name,p.PrizeName,getdate() as WinDate
        //                from Users u join Prizes p on u.PrizesBonus=p.RequiredBonus
        //                where not exists (select 1 from PrizeWinners pm where pm.UserId=u.UserId)";
        //            using (var command = new SqlCommand(query, conn))
        //            {
        //                int rowsAffected = await command.ExecuteNonQueryAsync();
        //                Console.WriteLine($"{rowsAffected} added into PrizeWinners");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error during sync: {ex.Message}");
        //    }
        //}
    }
}
