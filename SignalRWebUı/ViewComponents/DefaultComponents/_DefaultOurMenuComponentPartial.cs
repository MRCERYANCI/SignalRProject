using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUı.Dtos.CategoryDtos;
using SignalRWebUı.Dtos.ProductDtos;
using SignalRWebUı.Models;

namespace SignalRWebUı.ViewComponents.DefaultComponents
{
    public class DefaultOurMenuComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultOurMenuComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            CokluYapı cokluYapı = new CokluYapı();

            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7121/api/Product/ResultGetProductsWithCategories");
            var categoryresponsemessage = await client.GetAsync("https://localhost:7121/api/Category");
            if (responsemessage.IsSuccessStatusCode && categoryresponsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();//Bu veri json trü
                var categoryjsondata = await categoryresponsemessage.Content.ReadAsStringAsync();//Bu veri json trü

                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                var categoryvalues = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryjsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır

                cokluYapı.ResultProductDtos = new List<ResultProductDto>();
                cokluYapı.ResultCategoryDtos = new List<ResultCategoryDto>();

                foreach(var product in values)
                {
                    ResultProductDto resultProductDto = new ResultProductDto()
                    {
                        CategoryName = product.CategoryName,
                        ProductName = product.ProductName,
                        ProductDescription = product.ProductDescription,
                        ProductPrice = product.ProductPrice,
                        ProductImageUrl = product.ProductImageUrl,
                        ProductID = product.ProductID,
                        ProductStatus = product.ProductStatus
                    };
                    cokluYapı.ResultProductDtos.Add(resultProductDto);
                }

                foreach (var category in categoryvalues)
                {
                    ResultCategoryDto resultCategoryDto = new ResultCategoryDto()
                    {
                        CategoryName = category.CategoryName
                    };

                    cokluYapı.ResultCategoryDtos.Add(resultCategoryDto);
                }
                return View(cokluYapı);
            }
            return View();
        }
    }
}
