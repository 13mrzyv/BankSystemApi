using BankSystem.Repository.UnitOfWork;
using BankSystem.SQL.Server.Repositories.PrizeRepository;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly IServiceProvider _serviceProvider;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public PrizesBackGroundService(IServiceProvider serviceProvider, IServiceScopeFactory serviceScopeFactory)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await SyncTableAsync();
                await Task.Delay(TimeSpan.FromSeconds(20), stoppingToken);
            }
        }
        private async Task SyncTableAsync()
        {
            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var _unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                await _unitOfWork.PrizeRepository.SyncTableQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during sync: {ex.Message}");
            }
        }
    }
}
