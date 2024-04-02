using SignalR.EntityLayer.Entities;
using SignalRDataAccessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalRDataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(SignalRContext signalRContext) : base(signalRContext)
        {
        }

        public int BookinCount()
        {
            using(var context = new SignalRContext())
            {
                return context.Bookings.Count();
            }
        }

        public void BookingDescriptionStatus(int id, string Desc)
        {
            using(var context = new SignalRContext())
            {
               var value = context.Bookings.Where(x=>x.BookingID == id).FirstOrDefault();
                if(value != null)
                {
                    value.Description = Desc;
                    context.Bookings.Update(value);
                    context.SaveChanges();
                }
            }
        }
    }
}
