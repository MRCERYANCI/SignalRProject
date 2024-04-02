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
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void TAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public List<Product> TGetAll()
        {
            return _productDal.GetAll();
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> TGetProductsWithCategories()
        {
            return _productDal.GetProductsWithCategories();
        }

        public List<Product> TLinqList(Expression<Func<Product, bool>> filter)
        {
           return _productDal.LinqList(filter);
        }

        public Product TLinqListGet(Expression<Func<Product, bool>> filter)
        {
            return _productDal.LinqListGet(filter);
        }

		public int TProductCount()
		{
			return _productDal.ProductCount();
		}

		public int TProductCountByCategoryNameDrink()
		{
			return _productDal.ProductCountByCategoryNameDrink();
		}

		public int TProductCountByCategoryNameHamburger()
		{
			return _productDal.ProductCountByCategoryNameHamburger();
		}

		public string TProductNamePriceByMaxPrice()
		{
			return _productDal.ProductNamePriceByMaxPrice();
		}

		public string TProductNamePriceByMinPrice()
		{
			return _productDal.ProductNamePriceByMinPrice();
		}

		public string TProductPriceAvg()
		{
			return _productDal.ProductPriceAvg();
		}

		public string TProductPriceByHamburger()
		{
            return _productDal.ProductPriceByHamburger();
		}

        public string TTotalProduct()
        {
            return _productDal.TotalProduct();
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}
