using AutoMapper;
using SignalR.EntityLayer.Entities;
using SignalRDtoLayer.BasketDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.GeneralMapping
{
    public class BasketMapping : Profile
    {
        public BasketMapping()
        {
            CreateMap<CreateBasketDto, Basket>().ReverseMap();
        }
    }
}
