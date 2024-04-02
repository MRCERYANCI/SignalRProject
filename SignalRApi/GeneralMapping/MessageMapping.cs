using AutoMapper;
using SignalRDtoLayer.MessageDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.GeneralMapping
{
	public class MessageMapping : Profile
	{
        public MessageMapping()
        {
			CreateMap<ResultMessageDto, Message>().ReverseMap();
			CreateMap<CreateMessageDto, Message>().ReverseMap();
			CreateMap<UpdateMessageDto, Message>().ReverseMap();
		}
    }
}
