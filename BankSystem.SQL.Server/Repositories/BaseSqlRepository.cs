using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.SQL.Server.Repositories
{
    public class BaseSqlRepository
    {
        private readonly string _connectionString;

        public BaseSqlRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<SqlConnection> OpenSqlConnectionAsync()
        {
            try
            {
                var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();
                return connection;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error opening SQL connection: {ex.Message}");
                throw new Exception("Failed to open SQL connection", ex);
            }

        }
    }
}
