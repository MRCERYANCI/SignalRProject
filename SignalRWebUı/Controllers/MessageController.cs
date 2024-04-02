using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUı.Dtos.MessageDtos;
using System.Text;

namespace SignalRWebUı.Controllers
{
	public class MessageController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public MessageController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddNewMessage(CreateMessageDto createMessageDto)
		{
			createMessageDto.MessageSendDate = DateTime.Now;
			createMessageDto.MessageStatus = false;
			var client = _httpClientFactory.CreateClient();//İstemciyi Oluştruduk
			var jsonData = JsonConvert.SerializeObject(createMessageDto);//Modelden gelen veriyi Json Türüne Çevirdik, Normal Veriyi Json Türüne Çevirmek için SerializeObject Kullanılır
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//İçeriğin dönüşümü için kullancaz(content,encoding,mediaType)
			var responseMessage = await client.PostAsync("https://localhost:7121/api/Message", stringContent);
			if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
			{
				return Json("ok");
			}
            return RedirectToAction("Index", "Default");
        }

		[HttpGet]
		public async Task<IActionResult> GetMessageIndex()
		{
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7121/api/Message");
            if (responsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();//Bu veri json trü
                var values = JsonConvert.DeserializeObject<List<ResultMessageDto>>(jsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                return View(values);
            }
            return View();
        }

		public async Task<IActionResult> DeleteMessage(int MessageId)
		{
			var client = _httpClientFactory.CreateClient();//İstemciyi Oluşturduk
			var responseMessage = await client.DeleteAsync($"https://localhost:7121/api/Message?id={MessageId}");
			if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
			{
				return RedirectToAction("GetMessageIndex");
			}
			return RedirectToAction("GetMessageIndex");
		}

		[HttpGet]
		public async Task<IActionResult> GetMessage(int MessageId)
		{
			var client = _httpClientFactory.CreateClient();
			var responsemessage = await client.GetAsync($"https://localhost:7121/api/Message/GetMessage?MessageId={MessageId}");
			if (responsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
			{
				var jsondata = await responsemessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateMessageDto>(jsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> GetMessage(UpdateMessageDto updateMessageDto)
		{
			updateMessageDto.MessageStatus = true;
			var client = _httpClientFactory.CreateClient();//İstemciyi Oluştruduk
			var jsonData = JsonConvert.SerializeObject(updateMessageDto);//Modelden gelen veriyi Json Türüne Çevirdik
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//İçeriğin dönüşümü için kullancaz(content,encoding,mediaType)
			var responseMessage = await client.PutAsync("https://localhost:7121/api/Message", stringContent);
			if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
			{
				return RedirectToAction("GetMessageIndex");
			}
			return View();
		}


        [HttpGet]
        public async Task<IActionResult> GetContentMessage(int MessageId)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync($"https://localhost:7121/api/Message/GetMessage?MessageId={MessageId}");
            if (responsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateMessageDto>(jsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                return View(values);
            }
            return View();
        }
    }
}
