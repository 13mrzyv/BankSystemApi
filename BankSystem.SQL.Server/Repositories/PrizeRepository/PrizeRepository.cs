using BankSystem.Domain.Entities;
using BankSystem.Repository.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.SQL.Server.Repositories.PrizeRepository
{
    public class PrizeRepository : BaseSqlRepository, IPrizeRepository
    {
        public PrizeRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<Prize> DeletePrizeById(int prizeId)
        {
            var conn = await OpenSqlConnectionAsync();
            var prize = await conn.QueryFirstOrDefaultAsync($"Delete from Prizes where PrizeId={prizeId}");
            await conn.CloseAsync();
            return prize;
        }

        public async Task<Prize> GetPrizeById(int prizeId)
        {
            var conn = await OpenSqlConnectionAsync();
            var prize = await conn.QueryFirstOrDefaultAsync<Prize>($"select * from Prizes where PrizeId={prizeId}");
            await conn.CloseAsync();
            return prize;
        }

        public async Task<IEnumerable<Prize>> GetPrizes()
        {
            var conn = await OpenSqlConnectionAsync();
            var users = await conn.QueryAsync<Prize>($"select * from Prizes");
            await conn.CloseAsync();
            return users;
        }

        public async Task<bool> InsertPrize(Prize prize)
        {
            var conn = await OpenSqlConnectionAsync();
            var InsertedColumbs = await conn.ExecuteAsync($"insert into Prizes(PrizeId,PrizeName,RequiredBonus) values(@prizeid,@prizename,@requiredbonus)",
                new { prizeid = prize.PrizeId, prizename = prize.PrizeName, requiredbonus = prize.RequiredBonus });
            await conn.CloseAsync();
            return InsertedColumbs != 0;
        }

        public async Task<bool> UpdatePrize(Prize prize)
        {
            var conn = await OpenSqlConnectionAsync();
            var InsertedColumbs = await conn.ExecuteAsync($"update Prizes set PrizeId=@prizeid, PrizeName=@prizename, RequiredBonus=@requiredbonus where PrizeId={prize.PrizeId}",
                new { prizeid = prize.PrizeId, prizename = prize.PrizeName, requiredbonus = prize.RequiredBonus });
            await conn.CloseAsync();
            return InsertedColumbs != 0;
        }
        
        public async Task SyncTableQuery()
        {
            var conn = await OpenSqlConnectionAsync();
            await conn.ExecuteAsync(@"insert into PrizeWinners(UserId,UserName,Prize,WinDate)
                        select u.UserId,u.Name,p.PrizeName,getdate() as WinDate
                        from Users u join Prizes p on u.PrizesBonus=p.RequiredBonus
                        where not exists (select 1 from PrizeWinners pm where pm.UserId=u.UserId)");

            await conn.CloseAsync();
        }

        async Task IPrizeRepository.SyncTableQuery()
        {
            var conn = await OpenSqlConnectionAsync();
            await conn.ExecuteAsync(@"insert into PrizeWinners(UserId,UserName,Prize,WinDate)
                        select u.UserId,u.Name,p.PrizeName,getdate() as WinDate
                        from Users u join Prizes p on u.PrizesBonus=p.RequiredBonus
                        where not exists (select 1 from PrizeWinners pm where pm.UserId=u.UserId)");

            await conn.CloseAsync();
        }
    }
}

