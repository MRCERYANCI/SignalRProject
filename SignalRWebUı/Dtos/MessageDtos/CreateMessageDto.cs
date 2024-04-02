namespace SignalRWebUı.Dtos.MessageDtos
{
	public class CreateMessageDto
	{
		public string NameSurname { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Subject { get; set; }
		public string MessageContent { get; set; }
		public DateTime MessageSendDate { get; set; }
		public bool MessageStatus { get; set; }
	}
}
