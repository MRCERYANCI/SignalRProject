using AutoMapper;
using SignalR.EntityLayer.Entities;
using SignalRDtoLayer.AboutDto;
using SignalRDtoLayer.BookingDto;

namespace SignalRApi.GeneralMapping
{
    public class BookingMapping : Profile
    {
        public BookingMapping()
        {
            CreateMap<ResultBookingDto, Booking>().ReverseMap();
            CreateMap<CreateBookingDto, Booking>().ReverseMap();
            CreateMap<UpdateBookingDto, Booking>().ReverseMap();
            CreateMap<GetBookingDto, Booking>().ReverseMap();
        }
    }
}
