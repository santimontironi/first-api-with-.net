using System.ComponentModel.DataAnnotations;

namespace ApiEcommerce.Models.Dtos
{
    public class UpdateCategoryDto
    {
        [Required(ErrorMessage = "El campo nombre es requerido")]
        [MaxLength(50, ErrorMessage = "El campo nombre no puede tener mas de 50 caracteres")]
        [MinLength(3, ErrorMessage = "El campo nombre no puede tener menos de 3 caracteres")]
        public string Name { get; set; } = string.Empty;
    }
}