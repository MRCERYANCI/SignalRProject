using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUı.Dtos.BasketDtos;
using System.Net.Http;
using System.Text;

namespace SignalRWebUı.Controllers
{
    [AllowAnonymous]
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasket(int PrdouctId)
        {
            CreateBasketDtos createBasketDtos = new CreateBasketDtos();
            createBasketDtos.ProductId = PrdouctId;
            createBasketDtos.Count = 1;
            createBasketDtos.MenuTableId = 1;


            var client = _httpClientFactory.CreateClient();//İstemciyi Oluştruduk
            var jsonData = JsonConvert.SerializeObject(createBasketDtos);//Modelden gelen veriyi Json Türüne Çevirdik, Normal Veriyi Json Türüne Çevirmek için SerializeObject Kullanılır
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//İçeriğin dönüşümü için kullancaz(content,encoding,mediaType)
            var responseMessage = await client.PostAsync("https://localhost:7121/api/Basket", stringContent);
            if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
            {
                return RedirectToAction("Index");
            }
            return Json(createBasketDtos);
        }

        public async Task<IActionResult> DeleteBasket(int BasketId)
        {
            var client = _httpClientFactory.CreateClient();//İstemciyi Oluşturduk
            var responseMessage = await client.DeleteAsync($"https://localhost:7121/api/Basket?BasketId={BasketId}");
            if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
            {
                return Json(BasketId);
            }
            return View();
        }
    }
}
