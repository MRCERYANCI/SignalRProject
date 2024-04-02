using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.SocialMediaDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            return Ok(_mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetAll()));
        }

        [HttpPost]
        public IActionResult AddSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var values = _mapper.Map<SocialMedia>(createSocialMediaDto);
            _socialMediaService.TAdd(values);
            return Ok("Hakkımda Başarılı Bir Şekilde Eklenmiştir");
        }
        [HttpDelete]
        public IActionResult DeleteSocialMedia(int id)
        {
            var values = _socialMediaService.TGetById(id);
            _socialMediaService.TDelete(values);
            return Ok("Hakkımda Başarılı Bir Şekilde Silinmiştir");
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var values = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            _socialMediaService.TUpdate(values);
            return Ok("Hakkımda Alana Başarılı Bir Şekilde Güncellenmiştir");
        }

        [HttpGet("GetSocialMedia")]
        public IActionResult GetSocialMedia(int SocialMediaId)
        {
            var values = _socialMediaService.TGetById(SocialMediaId);
            return Ok(values);
        }
    }
}
