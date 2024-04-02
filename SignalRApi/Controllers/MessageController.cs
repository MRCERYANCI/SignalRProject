using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.MessageDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		private readonly IMessageService _messageService;
		private readonly IMapper _mapper;

		public MessageController(IMessageService messageService, IMapper mapper)
		{
			_messageService = messageService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult MessageList()
		{
			return Ok(_mapper.Map<List<ResultMessageDto>>(_messageService.TGetAll()));
		}

		[HttpPost]
		public IActionResult AddMessage(CreateMessageDto createMessageDto)
		{
			var values = _mapper.Map<Message>(createMessageDto);
			_messageService.TAdd(values);
			return Ok("Mesaj Başarılı Bir Şekilde Eklenmiştir");
		}
		[HttpDelete]
		public IActionResult DeleteMessage(int id)
		{
			var values = _messageService.TGetById(id);
			_messageService.TDelete(values);
			return Ok("Mesaj Başarılı Bir Şekilde Silinmiştir");
		}

		[HttpPut]
		public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
		{
			var values = _mapper.Map<Message>(updateMessageDto);
			_messageService.TUpdate(values);
			return Ok("Mesaj Alanı Başarılı Bir Şekilde Güncellenmiştir");
		}

		[HttpGet("GetMessage")]
		public IActionResult GetMessage(int MessageId)
		{
			var values = _messageService.TGetById(MessageId);
			return Ok(values);
		}
	}
}
