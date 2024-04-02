using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUı.Dtos.MenuTableDtos
{
    public class UpdateMenuTableDto
    {
        public int MenuTableId { get; set; }
        public string MenuName { get; set; }
        public bool MenuStatus { get; set; }
    }
}
