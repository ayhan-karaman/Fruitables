using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Dtos.IdentityDtos
{
    public class LoginDto
    {
        private string? _returnUrl;

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "E Posta adresinizi giriniz.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifrenizi giriniz")]
        public string Password { get; set; }

        public string ReturnUrl
        {
            get { return _returnUrl is null ? "/" : _returnUrl; }
            set { _returnUrl = value; }
        }
        
    }
}