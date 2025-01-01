using BankSystem.Application.Mapping;
using BankSystem.Application.Services;
using BankSystem.Domain.Entities;
using BankSystem.Domain.Services;
using BankSystem.Repository.Repositories;
using BankSystem.Repository.UnitOfWork;
using BankSystem.SQL.Server.Repositories.PrizeRepository;
using BankSystem.SQL.Server.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using System.Text;
using AutoMapper.Extensions.Microsoft.DependencyInjection;


//
var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var jwtKey = jwtSettings["JwtKey"];

if (string.IsNullOrEmpty(jwtKey))
{
    throw new InvalidOperationException("JWT anahtarý yapýlandýrmada eksik. Lütfen `JwtKey` deðerini `appsettings.json` dosyasýna ekleyin.");
}

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = true; // Geliþtirme ortamýnda ise `false` olabilir
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]))
        };
    }); 
builder.Services.AddAuthorization();

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPrizeService, PrizeService>();
builder.Services.AddScoped<IAuthService, AuthService>();

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

