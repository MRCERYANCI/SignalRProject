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
	public class EfMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCaseDal
	{
		public EfMoneyCaseDal(SignalRContext signalRContext) : base(signalRContext)
		{
		}


		public string TotalMoneyCaseAmount()
		{
			using(var context = new SignalRContext())
			{
				return context.MoneyCases.Sum(x=>x.TotalAmount).ToString("C");
			}
		}
	}
}
