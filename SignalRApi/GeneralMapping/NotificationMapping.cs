using AutoMapper;
using SignalR.EntityLayer.Entities;
using SignalRDtoLayer.CategoryDto;
using SignalRDtoLayer.NotificationDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.GeneralMapping
{
	public class NotificationMapping : Profile
	{
        public NotificationMapping()
        {
			CreateMap<ResultNotificationDto, Notification>().ReverseMap();
			CreateMap<CreateNotificationDto, Notification>().ReverseMap();
			CreateMap<UpdateNotificationDto, Notification>().ReverseMap();
		}
    }
}
