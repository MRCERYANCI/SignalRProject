using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalREntityLayer.Entities
{
	public class MenuTable
	{
		[Key]
        public int MenuTableId { get; set; }
        public string MenuName { get; set; }
        public bool MenuStatus { get; set; }

        //MenuTable ve Basket Arası İlişki
        public ICollection<Basket> Baskets { get; set; }
    }
}
