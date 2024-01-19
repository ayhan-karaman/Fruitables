using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Dtos.CategoryDtos
{
    public record CategoryDtoForUpdate : CategoryDto
    {
        public int Id { get; init; }
    }
}