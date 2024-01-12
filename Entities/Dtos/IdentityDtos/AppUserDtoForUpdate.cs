using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Dtos.IdentityDtos
{
    public record AppUserDtoForUpdate : AppUserDto
    {
        public HashSet<string> AppUserRoles { get; set; } = new();
    }
}