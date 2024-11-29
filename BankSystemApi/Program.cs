using BankSystem.Application.Services;
using BankSystem.Domain.Services;
using BankSystem.Repository.Repositories;
using BankSystem.Repository.UnitOfWork;
using BankSystem.SQL.Server.Repositories.PrizeRepository;
using BankSystem.SQL.Server.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPrizeService, PrizeService>();

builder.Services.AddHostedService<PrizesBackGroundService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
