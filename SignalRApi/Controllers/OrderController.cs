using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService _orderService;

		public OrderController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpGet("GetTotalOrderCount")]
		public IActionResult GetTotalOrderCount()
		{
			return Ok(_orderService.TTotalOrderCount());
		}

		[HttpGet("GetActiveOrderCount")]
		public IActionResult GetActiveOrderCount()
		{
			return Ok(_orderService.TActiveOrderCount());
		}

		[HttpGet("GetLastOrderPrice")]
		public IActionResult GetLastOrderPrice()
		{
			return Ok(_orderService.TLastOrderPrice());
		}

		[HttpGet("GetTodayTotalPrice")]
		public IActionResult GetTodayTotalPrice()
		{
			return Ok(_orderService.TTodayTotalPrice());
		}

	}
}
