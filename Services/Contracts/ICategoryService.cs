using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos.CategoryDtos;
using Entities.Models;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories(bool tracking);
        CategoryDtoForUpdate GetCategoryDtoForUpdate(int id);
        void CreateOneCategory(CategoryDtoForInsertion categoryDto);
        void UpdateOneCategory(CategoryDtoForUpdate categoryDto);
        void DeleteOneCategory(int id);
    }
}