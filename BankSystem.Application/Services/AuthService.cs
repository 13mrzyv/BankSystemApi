//using Amazon.Runtime.Internal.Util;
//using Azure;
//using Azure.Core;
//using BankSystem.Domain.Dtos;
//using BankSystem.Domain.Dtos.UserRequests;
//using BankSystem.Domain.Services;
//using BankSystem.Repository.UnitOfWork;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BankSystem.Application.Services
//{
//    public class AuthService : IAuthService
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        public AuthService(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        public async Task<bool> CreateUser(CustomerRegistration _user)
//        {
//            var result = await _unitOfWork.AuthRepository.CreateUser(_user);
//            return result;
//        }
//    }
//}
