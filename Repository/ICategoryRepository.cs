using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEcommerce.Repository
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();

        Category CreateCategory(Category category);

        Category UpdateCategory(Category category);

        Category DeleteCategory(Category category);

        Category? GetCategory(int id);
        
        bool CategoryExists(int id);

        bool CategoryExists(string name);
    }
}