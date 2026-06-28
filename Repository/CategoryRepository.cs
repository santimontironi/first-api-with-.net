using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEcommerce.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly ApplicationDbContext _contextDb; //private readonly en este caso se usa para la inyección de dependencias. que esto significa que la variable es privada y solo se puede acceder desde la clase que la define, en este caso esta clase es CategoryRepository.

        public CategoryRepository(ApplicationDbContext contextDb) // esta function es el constructor y lo que hace es recibir el contexto de la base de datos
        {
            _contextDb = contextDb;
        }

        public ICollection<Category> GetCategories()
        {
            return _contextDb.Categories.ToList();
        }

        public Category? GetCategory(int id)
        {
            return _contextDb.Categories.FirstOrDefault(c => c.Id == id);
        }

        public Category CreateCategory(Category category)
        {   
            category.CreationDate = DateTime.Now;
            _contextDb.Add(category);
            _contextDb.SaveChanges();
            return category;
        }

        public Category UpdateCategory(Category category)
        {
            _contextDb.SaveChanges();
            return category;
        }

        public Category DeleteCategory(Category category)
        {
            _contextDb.Remove(category);
            _contextDb.SaveChanges();
            return category;
        }

        public bool CategoryExists(int id)
        {
            return _contextDb.Categories.Any(c => c.Id == id);
        }

        public bool CategoryExists(string name)
        {
            return _contextDb.Categories.Any(c => c.Name.ToLower().Trim() == name.ToLower().Trim());
        }

    }
}