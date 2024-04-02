using SignalRWebUı.Dtos.CategoryDtos;
using SignalRWebUı.Dtos.ProductDtos;

namespace SignalRWebUı.Models
{
    public class CokluYapı
    {
        public List<ResultProductDto> ResultProductDtos { get; set; }
        public List<ResultCategoryDto> ResultCategoryDtos { get; set; }
    }
}
