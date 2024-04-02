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
	public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(SignalRContext signalRContext) : base(signalRContext)
        {
           
        }

		public int AciveCategoryCount()
		{
			using (var context = new SignalRContext())
			{
				return context.Categories.Count(x=>x.CategoryStatus==true);
			}
		}

		public int CategoryCount()
		{
			using(var context = new SignalRContext())
			{
				return context.Categories.Count();
			}
		}

		public int pasiveCategoryCount()
		{
			using (var context = new SignalRContext())
			{
				return context.Categories.Count(x => x.CategoryStatus == false);
			}
		}
	}
}
