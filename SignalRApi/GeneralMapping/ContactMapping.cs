using AutoMapper;
using SignalR.EntityLayer.Entities;
using SignalRDtoLayer.CategoryDto;
using SignalRDtoLayer.ContactDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.GeneralMapping
{
    public class ContactMapping : Profile
    {
        public ContactMapping()
        {
            CreateMap<ResultContactDto, Contact>().ReverseMap();
            CreateMap<CreateContactDto, Contact>().ReverseMap();
            CreateMap<UpdateContactDto, Contact>().ReverseMap();
            CreateMap<GetContactDto, Contact>().ReverseMap();
        }
    }
}
