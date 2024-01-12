using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Dtos.IdentityDtos
{
    public record AppUserDto
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Ad bilgisi boş bırakılamaz!")]
        public string FirstName { get; init; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Soyad bilgisi boş bırakılamaz!")]
        public string LastName { get; init; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz!")]
        public string UserName { get; init; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Geçerli bir email adresi giriniz!")]
        [Required(ErrorMessage = "Email bilgisi boş bırakılamaz!")]
        public string Email { get; init; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Geçerli bir telefon numarası giriniz!")]
        public string? PhoneNumber { get; init; }
        public HashSet<string> Roles { get; set; } = new();
    }
}