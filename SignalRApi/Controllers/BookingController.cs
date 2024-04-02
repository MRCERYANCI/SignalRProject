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
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            return Ok(_mapper.Map<List<ResultBookingDto>>(_bookingService.TGetAll()));
        }

        [HttpPost]
        public IActionResult AddBooking(CreateBookingDto createBookingDto)
        {
            var values = _mapper.Map<Booking>(createBookingDto);
            _bookingService.TAdd(values);
            return Ok("Rezervasyon Başarılı Bir Şekilde Eklenmiştir");
        }
        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            var values = _bookingService.TGetById(id);
            _bookingService.TDelete(values);
            return Ok("Rezervasyon Başarılı Bir Şekilde Silinmiştir");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var values = _mapper.Map<Booking>(updateBookingDto);
            _bookingService.TUpdate(values);
            return Ok("Rezervasyon Alana Başarılı Bir Şekilde Güncellenmiştir");
        }

        [HttpGet("GetBooking")]
        public IActionResult GetBooking(int BookingId)
        {
            var values = _bookingService.TGetById(BookingId);
            return Ok(values);
        }

        [HttpGet("BookingUpdateStatus")]
        public IActionResult GetBooking(int BookingId,string Desc)
        {
            _bookingService.TBookingDescriptionStatus(BookingId, Desc);
            return Ok();
        }
    }
}
