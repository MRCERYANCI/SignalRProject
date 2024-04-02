using AutoMapper;
using SignalR.EntityLayer.Entities;
using SignalRDtoLayer.BookingDto;
using SignalRDtoLayer.CategoryDto;

namespace SignalRApi.GeneralMapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<ResultCategoryDto, Category>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
            CreateMap<GetCategoryDto, Category>().ReverseMap();
        }
    }
}
