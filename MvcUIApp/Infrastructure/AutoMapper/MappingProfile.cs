using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Dtos.AddressDtos;
using Entities.Models;

namespace MvcUIApp.Infrastructure.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<AddressDtoForInsertion, Address>();
        }
    }
}