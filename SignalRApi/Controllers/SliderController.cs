
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.SliderDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            return Ok(_mapper.Map<List<ResultSliderDto>>(_sliderService.TGetAll()));
        }

        [HttpPost]
        public IActionResult AddSlider(CreateSliderDto createSliderDto)
        {
            var values = _mapper.Map<Slider>(createSliderDto);
            _sliderService.TAdd(values);
            return Ok("Slider Başarılı Bir Şekilde Eklenmiştir");
        }
        [HttpDelete]
        public IActionResult DeleteSlider(int id)
        {
            var values = _sliderService.TGetById(id);
            _sliderService.TDelete(values);
            return Ok("Slider Başarılı Bir Şekilde Silinmiştir");
        }

        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            var values = _mapper.Map<Slider>(updateSliderDto);
            _sliderService.TUpdate(values);
            return Ok("Slider Alana Başarılı Bir Şekilde Güncellenmiştir");
        }

        [HttpGet("GetSlider")]
        public IActionResult GetSlider(int SliderId)
        {
            var values = _sliderService.TGetById(SliderId);
            return Ok(values);
        }
    }
}
