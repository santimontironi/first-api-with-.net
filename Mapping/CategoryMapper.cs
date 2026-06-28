using Riok.Mapperly.Abstractions;
using ApiEcommerce.Models.Dtos;

namespace ApiEcommerce.Mapping
{
    // La clase y los métodos son partial para que Mapperly pueda generar sus implementaciones en tiempo de compilación (en obj/).
    // El compilador une ambas partes en un solo ensamblado; en runtime no hay ninguna lógica de Mapperly involucrada.
    [Mapper]
    public partial class CategoryMapper
    {
        public partial CategoryDto ToDto(Category category); // se lee: CategoryDto va a tener los valores de Category
        public partial List<CategoryDto> ToDtoList(ICollection<Category> categories); // se lee: List<CategoryDto> va a tener los valores de cada Category de la colección

        [MapperIgnoreTarget(nameof(Category.Id))]
        [MapperIgnoreTarget(nameof(Category.CreationDate))]
        public partial Category FromDto(CreationCategoryDto dto); // se lee: Category va a tener los valores de CreationCategoryDto (Id y CreationDate los pone la DB) - se usa FromDto porque el cliente manda solo los datos de creación, no el objeto Category completo

    }
}
