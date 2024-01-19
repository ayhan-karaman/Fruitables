using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Dtos.CategoryDtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CategoryManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateOneCategory(CategoryDtoForInsertion categoryDto)
        {
            Category category = _mapper.Map<Category>(categoryDto);
            _manager.CategoryRepository.CreateEntity(category);
            _manager.Save();
        }

        public void DeleteOneCategory(int id)
        {
           Category category = GetOneCategory(id, true);
           _manager.CategoryRepository.DeleteEntity(category);
           _manager.Save();
        }

        public IEnumerable<Category> GetAllCategories(bool tracking)
        {
            return _manager.CategoryRepository.FindAll(tracking).ToList();
        }

        public CategoryDtoForUpdate GetCategoryDtoForUpdate(int id)
        {
            Category category = GetOneCategory(id, false);
            return _mapper.Map<CategoryDtoForUpdate>(category);
        }

        public void UpdateOneCategory(CategoryDtoForUpdate categoryDto)
        {
            Category category = _mapper.Map<Category>(categoryDto);
            _manager.CategoryRepository.UpdateEntity(category);
            _manager.Save();
        }

        private Category GetOneCategory(int id, bool tracking)
        {
            Category? category  = _manager.CategoryRepository.FindCondition(x => x.Id == id, tracking);
            if(category is null)
                throw new Exception("Category not found");
            return category;
        }
    }
}