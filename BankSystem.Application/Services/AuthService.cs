using Amazon.Runtime.Internal.Util;
using AutoMapper;
using Azure;
using Azure.Core;
using BankSystem.Domain.Dtos;
using BankSystem.Domain.Dtos.UserRequests;
using BankSystem.Domain.Entities;
using BankSystem.Domain.Services;
using BankSystem.Repository.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AuthService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateUser(CustomerRegistration _user)
        {
            var result = await _unitOfWork.AuthRepository.CreateUser(_user);
            return result;
        }

        public async Task<LoginResponseModel> Login(LoginRequestModel loginRequestModel)
        {
            var customer = _mapper.Map<CustomerRegistration>(loginRequestModel); //sagdaki soldakinnen alir
            var result = await _unitOfWork.AuthRepository.Login(customer);
            return result;
        }
    }
}
