using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.EntityLayer.Entities;
using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalRDtoLayer.ProductDto;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            return Ok(_mapper.Map<List<ResultProductDto>>(_productService.TGetAll()));
        }

        [HttpPost]
        public IActionResult AddProduct(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto);
            _productService.TAdd(values);
            return Ok("Hakkımda Başarılı Bir Şekilde Eklenmiştir");
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var values = _productService.TGetById(id);
            _productService.TDelete(values);
            return Ok("Hakkımda Başarılı Bir Şekilde Silinmiştir");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            _productService.TUpdate(values);
            return Ok("Hakkımda Alana Başarılı Bir Şekilde Güncellenmiştir");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int ProductId)
        {
            var values = _productService.TGetById(ProductId);
            return Ok(values);
        }

        [HttpGet("ResultGetProductsWithCategories")]
        public IActionResult GetProductsWithCategories()
        {
            using (var context = new SignalRContext())
            {
                var values = context.Products.Include(x => x.Category).Select(y => new ResultGetProductsWithCategories
                {
                    ProductDescription = y.ProductDescription,
                    ProductImageUrl = y.ProductImageUrl,
                    ProductID = y.ProductID,
                    ProductName = y.ProductName,
                    ProductPrice = y.ProductPrice,
                    ProductStatus = y.ProductStatus,
                    CategoryName = y.Category.CategoryName
                }).ToList();

                return Ok(values);
            }
        }

        [HttpGet("GetProductCount")]
        public IActionResult GetProductCount()
        {
            return Ok(_productService.TProductCount());
        }

		[HttpGet("GetProductCountByCategoryNameDrink")]
		public IActionResult GetProductCountByCategoryNameDrink()
		{
			return Ok(_productService.TProductCountByCategoryNameDrink());
		}

		[HttpGet("GetProductCountByCategoryNameHamburger")]
		public IActionResult GetProductCountByCategoryNameHamburger()
		{
			return Ok(_productService.TProductCountByCategoryNameHamburger());
		}

		[HttpGet("GetProductPriceAvg")]
		public IActionResult GetProductPriceAvg()
		{
			return Ok(_productService.TProductPriceAvg());
		}

		[HttpGet("GetProductNamePriceByMaxPrice")]
		public IActionResult GetProductNamePriceByMaxPrice()
		{
			return Ok(_productService.TProductNamePriceByMaxPrice());
		}

		[HttpGet("GetProductNamePriceByMinPrice")]
		public IActionResult GetProductNamePriceByMinPrice()
		{
			return Ok(_productService.TProductNamePriceByMinPrice());
		}


		[HttpGet("GetProductPriceByHamburger")]
		public IActionResult GetProductPriceByHamburger()
		{
			return Ok(_productService.TProductPriceByHamburger());
		}
	}
}
