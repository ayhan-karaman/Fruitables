using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos.IdentityDtos;
using Entities.Models.Identities;
using Microsoft.AspNetCore.Identity;

namespace Services.Contracts
{
    public interface IAppUserService
    {
        IEnumerable<AppRole> Roles { get; }
        IEnumerable<AppUser> GetAllAppUsers();
        Task<IdentityResult> CreateAppUserAsync(AppUserDtoForCreation appUserDto);
        Task UpdateAppUserAsync(AppUserDtoForUpdate appUserDto);
        Task<AppUserDtoForUpdate> GetOneAppUserForUpdateAsync(string userName);
        Task<IdentityResult> DeleteAppUserAsync(string userName);
    }
}