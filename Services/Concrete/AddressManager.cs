using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Dtos.AddressDtos;
using Entities.Models;
using Entities.Models.Identities;
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

        public void DeleteOneAddress(int id)
        {
            Address? address  = GetByIdOneAddress(id, true);
            _repositoryManager.AddressRepository.DeleteEntity(address);
            _repositoryManager.Save();
        }

        public  IEnumerable<Address> GetByUserAddresses(string userName)
        {
           return  _repositoryManager.AddressRepository.GetByUserNameAddresses(userName);
        }

        public AddressDtoForUpdate GetOneAddressDtoForUpdate(int id)
        {
            Address? address = GetByIdOneAddress(id, false);
            AddressDtoForUpdate addressDto = _mapper.Map<AddressDtoForUpdate>(address);
            return addressDto;
        }

        public async Task UpdateUserToAddress(AddressDtoForUpdate addressDto)
        {
            Address address = _mapper.Map<Address>(addressDto);
            AppUser? user = await _appUserService.GetOneByNameAppUserAsync(addressDto.UserName);
            address.AppUser = user;
            _repositoryManager.AddressRepository.UpdateEntity(address);
            _repositoryManager.Save();
        }

        private Address GetByIdOneAddress(int id, bool tracking)
        {
             Address? address = _repositoryManager.AddressRepository.FindCondition(x => x.Id == id, tracking);
             if(address is not null)
                return address;
             throw new Exception();
        }
    }
}