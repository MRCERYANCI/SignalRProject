using AutoMapper;
using SignalR.EntityLayer.Entities;
using SignalRDtoLayer.AboutDto;

namespace SignalRApi.GeneralMapping
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            CreateMap<ResultAboutDto, About>().ReverseMap();
            CreateMap<CreateAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();
            CreateMap<GetAboutDto, About>().ReverseMap();
        }
    }
}
