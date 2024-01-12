using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Dtos.IdentityDtos
{
    public record AppUserDtoForCreation : AppUserDto
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre bilgisi boş bırakılamaz!")]
         public string Password { get; init; }
    }
}