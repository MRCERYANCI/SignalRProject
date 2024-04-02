using AutoMapper;
using SignalR.EntityLayer.Entities;
using SignalRDtoLayer.MenuTableDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.GeneralMapping
{
    public class MenuTableMapping : Profile
    {
        public MenuTableMapping()
        {
            CreateMap<ResultMenuTableDto, MenuTable>().ReverseMap();
            CreateMap<CreateMenuTableDto, MenuTable>().ReverseMap();
            CreateMap<UpdateMenuTableDto, MenuTable>().ReverseMap();
        }
    }
}
