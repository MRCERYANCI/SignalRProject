using AutoMapper;
using SignalRDtoLayer.SliderDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.GeneralMapping
{
    public class SliderMapping : Profile
    {
        public SliderMapping()
        {
            CreateMap<ResultSliderDto, Slider>().ReverseMap();
            CreateMap<CreateSliderDto, Slider>().ReverseMap();
            CreateMap<UpdateSliderDto, Slider>().ReverseMap();
        }
    }
}
