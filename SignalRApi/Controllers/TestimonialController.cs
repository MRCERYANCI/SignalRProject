using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.TestimonialDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            return Ok(_mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetAll()));
        }

        [HttpPost]
        public IActionResult AddTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var values = _mapper.Map<Testimonial>(createTestimonialDto);
            _testimonialService.TAdd(values);
            return Ok("Hakkımda Başarılı Bir Şekilde Eklenmiştir");
        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var values = _testimonialService.TGetById(id);
            _testimonialService.TDelete(values);
            return Ok("Hakkımda Başarılı Bir Şekilde Silinmiştir");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var values = _mapper.Map<Testimonial>(updateTestimonialDto);
            _testimonialService.TUpdate(values);
            return Ok("Hakkımda Alana Başarılı Bir Şekilde Güncellenmiştir");
        }

        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int TestimonialId)
        {
            var values = _testimonialService.TGetById(TestimonialId);
            return Ok(values);
        }
    }
}
