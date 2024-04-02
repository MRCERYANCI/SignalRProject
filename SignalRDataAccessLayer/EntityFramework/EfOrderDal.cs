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
	public class EfOrderDal : GenericRepository<Order>, IOrderDal
	{
		public EfOrderDal(SignalRContext signalRContext) : base(signalRContext)
		{
		}

		public int ActiveOrderCount()
		{
			using (var context = new SignalRContext())
			{
				return context.Orders.Count(x=>x.Description == "Müşteri Masada");
			}
		}

		public string LastOrderPrice()
		{
			using (var context = new SignalRContext())
			{
				var values = context.Orders.OrderByDescending(x => x.OrderId).Select(y => y.TotalPrice).FirstOrDefault().ToString("C");
				return values;
			}
		}

		public string TodayTotalPrice()
		{
			using(var context = new SignalRContext())
			{
				DateTime SimdikiZaman = DateTime.Parse(DateTime.Now.ToShortDateString());
				return context.Orders.Where(x => x.Date == SimdikiZaman).Sum(x => x.TotalPrice).ToString("C");
			}
		}

		public int TotalOrderCount()
		{
			using(var context = new SignalRContext())
			{
				return context.Orders.Count();
			}
		}
	}
}
