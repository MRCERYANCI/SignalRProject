using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.BookingDto;
using SignalRDtoLayer.CategoryDto;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            return Ok(_mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetAll()));
        }

        [HttpPost]
        public IActionResult AddCategory(CreateCategoryDto createCategoryDto)
        {
            var values = _mapper.Map<Category>(createCategoryDto);
            _categoryService.TAdd(values);
            return Ok("Kategori Başarılı Bir Şekilde Eklenmiştir");
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var values = _categoryService.TGetById(id);
            _categoryService.TDelete(values);
            return Ok("Kategori Başarılı Bir Şekilde Silinmiştir");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var values = _mapper.Map<Category>(updateCategoryDto);
            _categoryService.TUpdate(values);
            return Ok("Kategori Alanı Başarılı Bir Şekilde Güncellenmiştir");
        }

        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int CategoryId)
        {
            var values = _categoryService.TGetById(CategoryId);
            return Ok(values);
        }

        [HttpGet("GetCategoryCount")]
        public IActionResult GetCategoryCount()
        {
            return Ok(_categoryService.TCategoryCount());
        }

		[HttpGet("GetActiveCategoryCount")]
		public IActionResult GetActiveCategoryCount()
		{
			return Ok(_categoryService.TAciveCategoryCount());
		}

		[HttpGet("GetPassiveCategoryCount")]
		public IActionResult GetPassiveCategoryCount()
		{
			return Ok(_categoryService.TpasiveCategoryCount());
		}

	}
}
