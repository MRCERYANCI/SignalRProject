using AutoMapper;
using SignalR.EntityLayer.Entities;
using SignalRDtoLayer.ContactDto;
using SignalRDtoLayer.DiscountDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.GeneralMapping
{
    public class DiscountMapping : Profile
    {
        public DiscountMapping()
        {
            CreateMap<ResultDiscountDto, Discount>().ReverseMap();
            CreateMap<CreateDiscountDto, Discount>().ReverseMap();
            CreateMap<UpdateDiscountDto, Discount>().ReverseMap();
            CreateMap<GetDiscountDto, Discount>().ReverseMap();
        }
    }
}
