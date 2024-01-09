using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;

        public CategoryManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateOneCategory(Category category)
        {
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

        public void UpdateOneCategory(Category category)
        {
            Category? category1 = GetOneCategory(category.Id, true);
            category1.Name  = category.Name;
            category1.Status = category.Status;
            _manager.CategoryRepository.UpdateEntity(category1);
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