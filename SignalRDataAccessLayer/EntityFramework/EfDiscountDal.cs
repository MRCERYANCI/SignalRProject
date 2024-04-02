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
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        public EfDiscountDal(SignalRContext signalRContext) : base(signalRContext)
        {
        }

        public void ChangeStatusDiscount(int id, bool Status)
        {
            using(var context = new SignalRContext())
            {
                var value = context.Discounts.Where(x=>x.DiscountID == id).FirstOrDefault();
                if(value != null)
                {
                    value.DiscountStatus = Status;
                    context.Discounts.Update(value);
                    context.SaveChanges();
                }
            }
        }
    }
}
