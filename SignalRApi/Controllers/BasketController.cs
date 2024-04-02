using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalRDtoLayer.BasketDto;
using SignalRDtoLayer.ProductDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketController(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        [HttpGet("GetBasketsByTableNumber")]
        public IActionResult GetBasketsByTableNumber(int MenuTableId)
        {
            var values = _basketService.TGetBasketsByTableNumber(MenuTableId);
            if (values != null)
            {
                return Ok(values);
            }
            else
                return BadRequest("Sepette Ürün Bulunamadı");
        }

        [HttpGet("GetBasketsProductByTableNumber")]
        public IActionResult GetBasketsProductByTableNumber(int MenuTableId)
        {
            using (var context = new SignalRContext())
            {
                var values = context.Baskets.Where(x => x.MenuTableId == MenuTableId).Include(x => x.Product).Select(y => new ResultGetBasketsByTableNumber
                {
                    Price = y.Price,
                    Count = y.Count,
                    TotalPrice = y.TotalPrice,
                    ProductName = y.Product.ProductName,
                    BasketId = y.BasketId
                }).ToList();

                return Ok(values);
            }
        }

        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto basketDto)
        {
            SignalRContext signalRContext = new SignalRContext();

            var BasketProductValues = signalRContext.Baskets.Where(x => x.MenuTableId == basketDto.MenuTableId && x.ProductId == basketDto.ProductId).FirstOrDefault();
            if(BasketProductValues != null)
            {
                int UrunAdeti = BasketProductValues.Count;
                decimal UrunBirimFiyati = BasketProductValues.Price;
                decimal ToplamFiyat = BasketProductValues.TotalPrice;

                BasketProductValues.Count += basketDto.Count;
                BasketProductValues.TotalPrice += basketDto.Count * UrunBirimFiyati;

                _basketService.TUpdate(BasketProductValues);
            }
            else
            {
                decimal Price = signalRContext.Products.Where(x => x.ProductID == basketDto.ProductId).Select(y => y.ProductPrice).FirstOrDefault();

                if (Price != null)
                {
                    _basketService.TAdd(new Basket()
                    {
                        Count = basketDto.Count,
                        MenuTableId = basketDto.MenuTableId,
                        Price = Price,
                        TotalPrice = basketDto.Count * Price,
                        ProductId = basketDto.ProductId
                    });
                }
            }

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteBasket(int BasketId)
        {
            var values = _basketService.TGetById(BasketId);
            _basketService.TDelete(values);
            return Ok();
        }
    }
}
