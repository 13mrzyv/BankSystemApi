using AutoMapper;
using BankSystem.Domain.Dtos.UserRequests;
using BankSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Application.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<LoginRequestModel,CustomerRegistration>().ReverseMap();
            CreateMap<UserInsertRequest, User>().ReverseMap();
        }
    }
}
