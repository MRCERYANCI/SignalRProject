using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalREntityLayer.Entities
{
	public class Order
	{
		[Key]
        public int OrderId { get; set; }
        public string TableNumber { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }

         //Order ve Order Details Arası İlişki
        public ICollection<OrderDetail> OrdeDetails { get; set; }
    }
}
