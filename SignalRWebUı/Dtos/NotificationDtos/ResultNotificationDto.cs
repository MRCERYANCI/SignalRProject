namespace SignalRWebUı.Dtos.NotificationDtos
{
	public class ResultNotificationDto
	{
		public int NotificationId { get; set; }
		public string NotificationType { get; set; }
		public string NotificationIcon { get; set; }
		public string NotificationDescription { get; set; }
		public DateTime NotificationDate { get; set; }
		public bool NotificationStatus { get; set; }
	}
}
