using Microsoft.EntityFrameworkCore;
using SignalRDataAccessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalRDataAccessLayer.Repositories;
using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDataAccessLayer.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(SignalRContext signalRContext) : base(signalRContext)
        {
        }

        public List<Basket> GetBasketsByTableNumber(int TableNumberId)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Where(x => x.MenuTableId == TableNumberId).Include(z=>z.Product).ToList();
            return values;
        }
    }
}
