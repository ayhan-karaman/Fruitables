using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Dtos.AddressDtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.Concrete
{
    public class AddressManager : IAddressService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;

        public AddressManager(IRepositoryManager repositoryManager, IAppUserService appUserService, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _appUserService = appUserService;
            _mapper = mapper;
        }

        public async Task CreateUserAddToAddress(string userName, AddressDtoForInsertion addressDto)
        {
             var user = await _appUserService.GetOneByNameAppUserAsync(userName);
             Address address = _mapper.Map<Address>(addressDto);
             _repositoryManager.AddressRepository.CreateUserAddToAddress(user, address);
             _repositoryManager.Save();
        }

        public  IEnumerable<Address> GetByUserAddresses(string userName)
        {
           return  _repositoryManager.AddressRepository.GetByUserNameAddresses(userName);
        }
        

    }
}