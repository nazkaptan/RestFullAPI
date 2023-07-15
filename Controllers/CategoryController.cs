using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestFullAPI.Infrastructure.Repositories.Interface;
using RestFullAPI.Models.DTOs.Category;
using RestFullAPI.Models.Entities.Concrete;
using System.Collections.Generic;

namespace RestFullAPI.Controllers
{
    // ProducesResponseType => Bir action methodu içeriisnde bir çok dönüş türü ve yolu bulunma ihtimali yüksektir.
    // Örneğin aşağıda bulunan Create methodunun içerisinde 2 adet değişik dönüş tipi bulunmaktarıd.
    // ProducesRepsonseType özniteliği kullanılarakj bu dönüş tipleri Swagger gibi araçlar tarafından web API dökümantasyonlarında istemcikler için daha açıklayıcı yanıt ayrıntıları belirtir.
    [ApiController, Route("api/[controller]"), Produces("application/json"), ProducesResponseType(400)]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //Swagger UI aracalığı ile API üzerinde bazı testler yapmak isteyen geliştiricel için bazı özet bilgiler ekiliyoruz ki ilgili geliştirici API'yi rahatlıkla test edebilsin. Yani API'nin yetenekleri hakkında açıklama yapıyoruz. İlgili Action methodunun ne parametre aldığı, ne iş yaptığı vb..
        /// <summary>
        /// Get list of categories
        /// </summary>
        /// <returns>returns List<GetCategoryDTO></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<GetCategoryDTO>))]
        public IActionResult GetCategory()
        {
            var categoryList = _repository.GetCategory();

            var objDto = new List<GetCategoryDTO>();

            foreach (var obj in categoryList)
            {
                objDto.Add(_mapper.Map<GetCategoryDTO>(obj));
            }

            return Ok(objDto);
        }

        /// <summary>
        /// Get indivisual category
        /// </summary>
        /// <param name="id">The Id of category</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetCategory")]
        [ProducesResponseType(200), ProducesResponseType(404)]
        public IActionResult GetCategory(int id)
        {
            var obj = _repository.GetCategory(id);
            if (obj is null) return NotFound();
            var objDto = _mapper.Map<GetCategoryDTO>(obj);
            return Ok(objDto);
        }

        /// <summary>
        /// Create a new category
        /// </summary>
        /// <param name="categoryDTO">In this process, Category name and description does required fields</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateCategory([FromBody] CreateCategoryDTO categoryDTO)
        {
            if (categoryDTO == null) return BadRequest(ModelState);

            if (_repository.CategoryExists(categoryDTO.Name))
            {
                ModelState.AddModelError("", "This category already exists..!");
                return StatusCode(404, ModelState);
            }

            Category category = _mapper.Map<Category>(categoryDTO);

            if (!_repository.CreateCategory(category))
            {
                ModelState.AddModelError("", $"Something went wrong when creating a category {category.Name} or {category.Description}");
                return StatusCode(500, ModelState);
            }

            return Ok(category);
        }

        /// <summary>
        /// Update Category
        /// </summary>
        /// <param name="id">You must to type into field a id information</param>
        /// <param name="categoryDTO">In this process, Category Name and Description does required fields</param>
        /// <returns></returns>
        [HttpPut("{id}", Name = "UpdateCategory")]
        public IActionResult UpdateCategory(int id, [FromQuery] UpdateCategoryDTO categoryDTO)
        {
            if(categoryDTO == null || categoryDTO.Id != id) 
                return BadRequest(ModelState);

            Category categoryObj = _mapper.Map<Category>(categoryDTO);

            if (!_repository.UpdateCategory(categoryObj))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record {categoryObj.Name}");
                return StatusCode(500, ModelState);
            }

            return Ok(categoryObj);
        }
        /// <summary>
        /// Delete the category
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            Category categoryObj = _repository.GetCategory(id);

            if(!_repository.DeleteCategory(categoryObj.Id))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record {categoryObj.Name}");
            }

            return NoContent();
        }

    }
}
