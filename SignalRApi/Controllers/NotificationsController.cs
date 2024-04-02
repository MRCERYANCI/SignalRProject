using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.NotificationDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

		public NotificationsController(INotificationService notificationService, IMapper mapper)
		{
			_notificationService = notificationService;
			_mapper = mapper;
		}

		[HttpGet]
        public IActionResult GettNotifications()
        {
            return Ok(_notificationService.TGetAll());
        }

        [HttpGet("{NotificationStatus}")]
        public IActionResult NotificatinCountByStatus(bool NotificationStatus)
        {
            return Ok(_notificationService.NotificatinCountByStatus(NotificationStatus));
        }

		[HttpPost]
		public IActionResult AddNotification(CreateNotificationDto createNotificationDto)
		{
			var values = _mapper.Map<Notification>(createNotificationDto);
			_notificationService.TAdd(values);
			return Ok("Bildirim Başarılı Bir Şekilde Eklenmiştir");
		}

		[HttpPut]
		public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
		{
			var values = _mapper.Map<Notification>(updateNotificationDto);
			_notificationService.TUpdate(values);
			return Ok("Bildirim Alanı Başarılı Bir Şekilde Güncellenmiştir");
		}

		[HttpDelete]
		public IActionResult DeleteNotification(int id)
		{
			var values = _notificationService.TGetById(id);
			_notificationService.TDelete(values);
			return Ok("Bildirim Başarılı Bir Şekilde Silinmiştir");
		}

		[HttpGet("GetNotification")]
		public IActionResult GetNotification(int NotificationId)
		{
			var values = _notificationService.TGetById(NotificationId);
			return Ok(values);
		}

        [HttpGet("NotificationStatusChangeTuUpdate")]
        public IActionResult NotificationStatusChangeTuUpdate(int NotificationId)
        {
			_notificationService.TNotificationChangeToTrue(NotificationId);
            return Ok();
        }


    }
}
