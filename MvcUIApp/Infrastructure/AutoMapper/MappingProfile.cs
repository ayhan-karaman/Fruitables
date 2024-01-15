using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Dtos.AddressDtos;
using Entities.Dtos.IdentityDtos;
using Entities.Dtos.OrderDtos;
using Entities.Models;
using Entities.Models.Identities;

namespace MvcUIApp.Infrastructure.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<AddressDtoForInsertion, Address>();
            CreateMap<AddressDtoForUpdate, Address>().ReverseMap();

            CreateMap<OrderDtoForInsertion, Order>();

            CreateMap<AppUserDtoForCreation, AppUser>();
            CreateMap<AppUserDtoForUpdate, AppUser>().ReverseMap();
            CreateMap<RegisterDto, AppUserDtoForCreation>();
        }
    }
}