using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Abstract;
using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Concrete
{
    public class BasketManager : IBasketService
    {

        private readonly IBasketDal _basketDal;
        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public void TAdd(Basket entity)
        {
            _basketDal.Add(entity);
        }

        public void TDelete(Basket entity)
        {
            _basketDal.Delete(entity);
        }

        public List<Basket> TGetAll()
        {
            return _basketDal.GetAll();
        }

        public List<Basket> TGetBasketsByTableNumber(int TableNumberId)
        {
            return _basketDal.GetBasketsByTableNumber(TableNumberId);
        }

        public Basket TGetById(int id)
        {
            return _basketDal.GetById(id);
        }

        public List<Basket> TLinqList(Expression<Func<Basket, bool>> filter)
        {
            return _basketDal.LinqList(filter);
        }

        public Basket TLinqListGet(Expression<Func<Basket, bool>> filter)
        {
            return _basketDal.LinqListGet(filter);
        }

        public void TUpdate(Basket entity)
        {
           _basketDal.Update(entity);
        }
    }
}
