using AutoMapper;
using SignalR.EntityLayer.Entities;
using SignalRDtoLayer.ProductDto;

namespace SignalRApi.GeneralMapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<ResultProductDto, Product>().ReverseMap();
            CreateMap<CreateProductDto, Product>().ReverseMap();
            CreateMap<UpdateProductDto, Product>().ReverseMap();
            CreateMap<GetProductDto, Product>().ReverseMap();
            CreateMap<ResultGetProductsWithCategories, Product>().ReverseMap();
        }
    }
}
