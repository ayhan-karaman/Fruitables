using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Dtos.CategoryDtos
{
    public record CategoryDto
    {
        [Required(ErrorMessage = "Kategori adını giriniz!")]
        public string Name { get; init; }
        public bool Status { get; init; } = true;
    }
}