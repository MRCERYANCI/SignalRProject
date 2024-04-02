using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDtoLayer.DiscountDto
{
    public class UpdateDiscountDto
    {
        public int DiscountID { get; set; }
        public string DiscountTitle { get; set; }
        public string DiscountAmount { get; set; } //Miktar
        public string DiscountDescription { get; set; } //Miktar
        public string DiscountImageUrl { get; set; } //Miktar
        public bool DiscountStatus { get; set; } //Miktar
    }
}
