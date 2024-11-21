using Models;
using Repositories;
using System.Diagnostics;

namespace Controllers
{
    public class CategoryController
    {
        private CategoryRepository categoryRepository;

        public event EventHandler<CategoryEventArgs> NewCategoryEventHandler;
        public event EventHandler<CategoryEventArgs> DeleteCategoryEventHandler;
        public event EventHandler<CategoryEventArgs> UpdateCategoryEventHandler;

        public CategoryController()
        {
            categoryRepository = new CategoryRepository();
        }

        public List<Category> GetCategories()
        {
            return categoryRepository.GetAll();
        }

        public void AddCategory(string name)
        {
            Category newCategory = new Category(name);

            if (GetCategories().Exists((category) => category.Equals(newCategory)))
            {
                throw new CategoryAlreadyExistsException($"New category: {name} already exists.");
            }

            categoryRepository.Add(newCategory);
            NewCategoryEventHandler?.Invoke(this, new CategoryEventArgs(newCategory));
        }

        public void ChangePodCategory(Category? newCategory, Pod pod)
        {
            if (newCategory == null || pod == null) return;

            categoryRepository.Update(pod.Guid, newCategory);
        }

        public void ChangeCategoryName(Category category, string newName)
        {
            if (category.Name == newName)
            {
                throw new CategoryNameException("The categories name can't be the same as the old name.");
            }
            category.Name = newName;

            categoryRepository.Update(category.Guid, category);
            UpdateCategoryEventHandler?.Invoke(this, new CategoryEventArgs(category));
        }

        public void RemoveCategory(Category category)
        {
            categoryRepository.Delete(category.Guid);
            DeleteCategoryEventHandler?.Invoke(this, new CategoryEventArgs(category));
        }
    }
}
