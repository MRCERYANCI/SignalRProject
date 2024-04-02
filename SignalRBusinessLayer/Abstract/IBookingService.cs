using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Abstract
{
    public interface IBookingService : IGenericService<Booking>
    {
        int TBookinCount();
        void TBookingDescriptionStatus(int id, string Desc);
    }
}
