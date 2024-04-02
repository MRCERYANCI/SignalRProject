    using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.AboutDto;
using SignalRDtoLayer.BookingDto;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            return Ok(_mapper.Map<List<ResultAboutDto>>(_aboutService.TGetAll()));
        }

        [HttpPost]
        public IActionResult AddAbout(CreateAboutDto createAboutDto)
        {
            var values = _mapper.Map<About>(createAboutDto);
            _aboutService.TAdd(values);
            return Ok("Hakkımda Başarılı Bir Şekilde Eklenmiştir");
        }
        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var values = _aboutService.TGetById(id);
            _aboutService.TDelete(values);
            return Ok("Hakkımda Başarılı Bir Şekilde Silinmiştir");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var values = _mapper.Map<About>(updateAboutDto);
            _aboutService.TUpdate(values);
            return Ok("Hakkımda Alana Başarılı Bir Şekilde Güncellenmiştir");
        }

        [HttpGet("GetAbout")]
        public IActionResult GetAbout(int AboutId)
        {
            var values = _aboutService.TGetById(AboutId);
            return Ok(values);
        }
    }
}
