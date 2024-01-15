using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Dtos.IdentityDtos;
using Entities.Models;
using Entities.Models.Identities;
using Microsoft.AspNetCore.Identity;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AppUserManager(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public  IEnumerable<AppRole> Roles =>  _roleManager.Roles;

        public async Task<IdentityResult> CreateAppUserAsync(AppUserDtoForCreation appUserDto)
        {
            AppUser user = _mapper.Map<AppUser>(appUserDto);
            var result = await _userManager.CreateAsync(user, appUserDto.Password);
            if(!result.Succeeded)
                throw new Exception("User could net be created.");
            if(appUserDto.Roles.Count > 0)
            {
                var roleResult = await _userManager.AddToRolesAsync(user, appUserDto.Roles);
                if(!roleResult.Succeeded)
                    throw new Exception("System have problems with roles.");
            }

            return result;
        }

        public async Task<IdentityResult> DeleteAppUserAsync(string userName)
        {
            AppUser?  user = await _userManager.FindByNameAsync(userName);
            return await _userManager.DeleteAsync(user);
        }

        public IEnumerable<AppUser> GetAllAppUsers()
        {
            return _userManager.Users.ToList();
        }

        public async Task<AppUserDtoForInformation> GetAppUserDtoForInformation(string userName)
        {
            AppUser? user = await GetOneAppUserAsync(userName);
            AppUserDtoForInformation userDtoForInformation = _mapper.Map<AppUserDtoForInformation>(user);
            return userDtoForInformation;
        }

        public async Task<AppUserDtoForUpdate> GetOneAppUserForUpdateAsync(string userName)
        {
            AppUser user = await GetOneAppUserAsync(userName);
            var appUserDto = _mapper.Map<AppUserDtoForUpdate>(user);
            appUserDto.Roles = new HashSet<string>(Roles.Select(x => x.Name).ToList());
            appUserDto.AppUserRoles = new HashSet<string>(await _userManager.GetRolesAsync(user));
            return appUserDto;
            
        }

        public async Task<AppUser> GetOneByNameAppUserAsync(string userName)
        {
            return await GetOneAppUserAsync(userName);
        }

        public async Task<IdentityResult> RegisterAppUserAsync(RegisterDto registerDto)
        {
            AppUserDtoForCreation appUserDtoForCreation = _mapper.Map<AppUserDtoForCreation>(registerDto);
            appUserDtoForCreation.Roles = new HashSet<string>(){"User"};
            var result =  await CreateAppUserAsync(appUserDtoForCreation);
            return result;
        }

        public async Task UpdateAppUserAsync(AppUserDtoForUpdate appUserDto)
        {
             AppUser? user = await GetOneAppUserAsync(appUserDto.UserName);
            user.FirstName = appUserDto.FirstName;
            user.LastName = appUserDto.LastName;
            user.PhoneNumber = appUserDto.PhoneNumber;
            user.UserName = appUserDto.UserName;
            var result = await _userManager.UpdateAsync(user);
            if(result.Succeeded)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                _ = await _userManager.RemoveFromRolesAsync(user, userRoles);
                _ = await _userManager.AddToRolesAsync(user, appUserDto.Roles);
            }
        }

       
        private async Task<AppUser> GetOneAppUserAsync(string userName)
        {
            AppUser? user = await _userManager.FindByNameAsync(userName);
            if(user is not null)
                return user;
            throw new Exception("User could not be found");
        }

       
    }
}