using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUı.Dtos.NotificationDtos;
using System.Text;

namespace SignalRWebUı.Controllers
{
	[AllowAnonymous]
	public class NotificationsController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public NotificationsController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responsemessage = await client.GetAsync("https://localhost:7121/api/Notifications");
			if (responsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
			{
				var jsondata = await responsemessage.Content.ReadAsStringAsync();//Bu veri json trü
				var values = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(jsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public IActionResult CreateNotification()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateNotification(CreateNotificationDto createNotificationDto)
		{
			if(createNotificationDto != null)
			{
				if (createNotificationDto.NotificationType == "notif-icon notif-primary")
					createNotificationDto.NotificationIcon = "la la-user-plus";

				else if (createNotificationDto.NotificationType == "notif-icon notif-success")
					createNotificationDto.NotificationIcon = "la la-comment";

				else if (createNotificationDto.NotificationType == "notif-icon notif-danger")
					createNotificationDto.NotificationType = "la la-heart";

				createNotificationDto.NotificationStatus = false;
				createNotificationDto.NotificationDate = DateTime.Now;

                var client = _httpClientFactory.CreateClient();//İstemciyi Oluştruduk
                var jsonData = JsonConvert.SerializeObject(createNotificationDto);//Modelden gelen veriyi Json Türüne Çevirdik, Normal Veriyi Json Türüne Çevirmek için SerializeObject Kullanılır
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//İçeriğin dönüşümü için kullancaz(content,encoding,mediaType)
                var responseMessage = await client.PostAsync("https://localhost:7121/api/Notifications", stringContent);
                if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
                {
                    return RedirectToAction("Index");
                }
            }
			return View();
		}

		public async Task<IActionResult> DeleteNotification(int NotificationId)
		{
			var client = _httpClientFactory.CreateClient();//İstemciyi Oluşturduk
			var responseMessage = await client.DeleteAsync($"https://localhost:7121/api/Notifications?id={NotificationId}");
			if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
			{
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> GetNotification(int NotificationId)
		{
			var client = _httpClientFactory.CreateClient();
			var responsemessage = await client.GetAsync($"https://localhost:7121/api/Notifications/GetNotification?NotificationId={NotificationId}");
			if (responsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
			{
				var jsondata = await responsemessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateNotificationDto>(jsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> GetNotification(UpdateNotificationDto updateNotificationDto)
		{
			if(updateNotificationDto != null)
			{
                if (updateNotificationDto.NotificationType == "notif-icon notif-primary")
                    updateNotificationDto.NotificationIcon = "la la-user-plus";

                else if (updateNotificationDto.NotificationType == "notif-icon notif-success")
                    updateNotificationDto.NotificationIcon = "la la-comment";

                else if (updateNotificationDto.NotificationType == "notif-icon notif-danger")
                    updateNotificationDto.NotificationType = "la la-heart";

                var client = _httpClientFactory.CreateClient();//İstemciyi Oluştruduk
                var jsonData = JsonConvert.SerializeObject(updateNotificationDto);//Modelden gelen veriyi Json Türüne Çevirdik
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//İçeriğin dönüşümü için kullancaz(content,encoding,mediaType)
                var responseMessage = await client.PutAsync("https://localhost:7121/api/Notifications", stringContent);
                if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
                {
                    return RedirectToAction("Index");
                }
            }

			return View();
		}



        public async Task<IActionResult> NotificationStatusChange(int? NotificationId)
        {
            if (NotificationId != null)
            {
                var client = _httpClientFactory.CreateClient();//İstemciyi Oluştruduk    
                var responseMessage = await client.GetAsync($"https://localhost:7121/api/Notifications/NotificationStatusChangeTuUpdate?NotificationId={NotificationId}");
                if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }
    }
}
