using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDtoLayer.BasketDto
{
    public class CreateBasketDto
    {
        public int Count { get; set; }
        public int ProductId { get; set; }
        public int MenuTableId { get; set; }
    }
}
