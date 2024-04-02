using Microsoft.EntityFrameworkCore;
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
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext signalRContext) : base(signalRContext)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            using(var context = new SignalRContext())
            {
                return context.Products.Include(x=>x.Category).ToList();
            }
        }

		public int ProductCount()
		{
			using (var context = new SignalRContext())
			{
                return context.Products.Count(x => x.ProductStatus == true);
			}
		}

		public int ProductCountByCategoryNameDrink()
		{
			using (var context = new SignalRContext())
			{
				return context.Products.Where(x => x.CategoryId == (context.Categories.Where(x => x.CategoryName == "İçecek").Select(y => y.CategoryID).FirstOrDefault())).Count();
			}
		}

		public int ProductCountByCategoryNameHamburger()
		{
			using (var context = new SignalRContext())
			{
				return context.Products.Where(x => x.CategoryId == (context.Categories.Where(x => x.CategoryName == "Hamburger").Select(y => y.CategoryID).FirstOrDefault())).Count();
			}
		}

		public string? ProductNamePriceByMaxPrice()
		{
			using (var context = new SignalRContext())
			{
				return context.Products.Where(x => x.ProductPrice == (context.Products.Max(y => y.ProductPrice))).Select(z => z.ProductName).FirstOrDefault();
			}
		}

		public string? ProductNamePriceByMinPrice()
		{
			using (var context = new SignalRContext())
			{
				return context.Products.Where(x => x.ProductPrice == (context.Products.Min(y => y.ProductPrice))).Select(z => z.ProductName).FirstOrDefault();
			}
		}

		public string ProductPriceAvg()
		{
			using (var context = new SignalRContext())
			{
				return context.Products.Average(x => x.ProductPrice).ToString("C");
			}
		}

		public string ProductPriceByHamburger()
		{
			using (var context = new SignalRContext())
			{
				return context.Products.Where(w=>w.CategoryId == (context.Categories.Where(y=>y.CategoryName == "Hamburger").Select(z=>z.CategoryID).FirstOrDefault())).Average(x => x.ProductPrice).ToString("C");
			}
		}

        public string TotalProduct()
        {
            using(var context = new SignalRContext())
			{
				return context.Products.Sum(x => x.ProductPrice).ToString("C");
			}
        }
    }
}
