using AutoMapper;
using SignalR.EntityLayer.Entities;
using SignalRDtoLayer.ProductDto;
using SignalRDtoLayer.SocialMediaDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.GeneralMapping
{
    public class SocialMediaMapping : Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<ResultSocialMediaDto, SocialMedia>().ReverseMap();
            CreateMap<CreateSocialMediaDto, SocialMedia>().ReverseMap();
            CreateMap<UpdateSocialMediaDto, SocialMedia>().ReverseMap();
            CreateMap<GetSocialMediaDto, SocialMedia>().ReverseMap();
        }
    }
}
