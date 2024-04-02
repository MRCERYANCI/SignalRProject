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
    public class DiscountManager : IDiscountService
    {
        IDiscountDal _discountDal;

        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

        public void TAdd(Discount entity)
        {
            _discountDal.Add(entity);
        }

        public void TChangeStatusDiscount(int id, bool Status)
        {
            _discountDal.ChangeStatusDiscount(id, Status);
        }

        public void TDelete(Discount entity)
        {
            _discountDal.Delete(entity);
        }

        public List<Discount> TGetAll()
        {
           return _discountDal.GetAll();
        }

        public Discount TGetById(int id)
        {
            return _discountDal.GetById(id);
        }

        public List<Discount> TLinqList(Expression<Func<Discount, bool>> filter)
        {
            return _discountDal.LinqList(filter);
        }

        public Discount TLinqListGet(Expression<Func<Discount, bool>> filter)
        {
            return _discountDal.LinqListGet(filter);
        }

        public void TUpdate(Discount entity)
        {
            _discountDal.Update(entity);
        }
    }
}
