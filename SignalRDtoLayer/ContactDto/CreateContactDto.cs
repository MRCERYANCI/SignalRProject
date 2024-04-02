using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDtoLayer.ContactDto
{
    public class CreateContactDto
    {
        public string ContactLocation { get; set; }
        public string ContactPhone { get; set; }
        public string ContactMail { get; set; }
        public string FooterTitle { get; set; }
        public string OpenDays { get; set; }
        public string OpenDaysDescription { get; set; }
        public string ContactFooterDescription { get; set; }
    }
}
