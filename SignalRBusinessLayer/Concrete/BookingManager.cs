using SignalR.EntityLayer.Entities;
using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public void TAdd(Booking entity)
        {
            _bookingDal.Add(entity);
        }

        public int TBookinCount()
        {
            return _bookingDal.BookinCount();
        }

        public void TBookingDescriptionStatus(int id, string Desc)
        {
            _bookingDal.BookingDescriptionStatus(id, Desc);
        }

        public void TDelete(Booking entity)
        {
            _bookingDal.Delete(entity);
        }

        public List<Booking> TGetAll()
        {
            return _bookingDal.GetAll();
        }

        public Booking TGetById(int id)
        {
           return _bookingDal.GetById(id);
        }

        public List<Booking> TLinqList(Expression<Func<Booking, bool>> filter)
        {
           return _bookingDal.LinqList(filter);
        }

        public Booking TLinqListGet(Expression<Func<Booking, bool>> filter)
        {
            return _bookingDal.LinqListGet(filter);
        }

        public void TUpdate(Booking entity)
        {
            _bookingDal.Update(entity);
        }
    }
}
