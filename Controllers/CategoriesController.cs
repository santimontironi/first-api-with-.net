using ApiEcommerce.Mapping;
using ApiEcommerce.Models.Dtos;
using ApiEcommerce.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiEcommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly CategoryMapper _mapper;

        public CategoriesController(ICategoryRepository categoryRepository, CategoryMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCategories()
        {
            var categories = _categoryRepository.GetCategories();

            if (categories == null || !categories.Any())
            {
                return NotFound("No categories found.");
            }

            return Ok(_mapper.ToDtoList(categories));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateCategory([FromBody] CreationCategoryDto categoryDto)
        {
            if (categoryDto == null)
            {
                return BadRequest("La cetegoria no existe.");
            }

            if (_categoryRepository.CategoryExists(categoryDto.Name))
            {
                return BadRequest("La categoria ya existe.");
            }

            var category = _mapper.FromDto(categoryDto);

            category = _categoryRepository.CreateCategory(category);

            return StatusCode(StatusCodes.Status201Created, _mapper.ToDto(category));
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCategory(int id)
        {
            var category = _categoryRepository.GetCategory(id);

            if (category == null)
            {
                return NotFound("Categoria no encontrada.");
            }

            return Ok(_mapper.ToDto(category));
        }

        [HttpPatch("{id:int}", Name = "UpdateCategory")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateCategory(int id, [FromBody] UpdateCategoryDto categoryDto)
        {
            if (categoryDto == null)
            {
                return BadRequest("Debe de ingresar el nombre nuevo de la categoria.");
            }

            var category = _categoryRepository.GetCategory(id);

            if (category == null)
            {
                return NotFound("Category not found.");
            }

            category.Name = categoryDto.Name;

            category = _categoryRepository.UpdateCategory(category);

            return Ok(_mapper.ToDto(category));
        }
    }
}
