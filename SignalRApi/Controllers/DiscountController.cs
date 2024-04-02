using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.DiscountDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            return Ok(_mapper.Map<List<ResultDiscountDto>>(_discountService.TGetAll()));
        }

        [HttpGet("DiscountListTrue")]
        public IActionResult DiscountListTrue()
        {
            return Ok(_mapper.Map<List<ResultDiscountDto>>(_discountService.TGetAll().Where(x => x.DiscountStatus == true)));
        }

        [HttpPost]
        public IActionResult AddDiscount(CreateDiscountDto createDiscountDto)
        {
            var values = _mapper.Map<Discount>(createDiscountDto);
            _discountService.TAdd(values);
            return Ok("Hakkımda Başarılı Bir Şekilde Eklenmiştir");
        }
        [HttpDelete]
        public IActionResult DeleteDiscount(int id)
        {
            var values = _discountService.TGetById(id);
            _discountService.TDelete(values);
            return Ok("Hakkımda Başarılı Bir Şekilde Silinmiştir");
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            var values = _mapper.Map<Discount>(updateDiscountDto);
            _discountService.TUpdate(values);
            return Ok("Hakkımda Alana Başarılı Bir Şekilde Güncellenmiştir");
        }

        [HttpGet("GetDiscount")]
        public IActionResult GetDiscount(int DiscountId)
        {
            var values = _discountService.TGetById(DiscountId);
            return Ok(values);
        }

        [HttpGet("DiscountStatus")]
        public IActionResult DiscountStatus(int DiscountId , bool Status)
        {
            _discountService.TChangeStatusDiscount(DiscountId, Status);
            return Ok();
        }
    }
}
