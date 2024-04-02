using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDataAccessLayer.Abstract
{
    public interface IProductDal: IGenericDal<Product>
    {
        List<Product> GetProductsWithCategories();
        int ProductCount();
        int ProductCountByCategoryNameHamburger();
        int ProductCountByCategoryNameDrink();
        string ProductPriceAvg();
        string ProductNamePriceByMaxPrice();
        string ProductNamePriceByMinPrice();
        string ProductPriceByHamburger();
        string TotalProduct();
    }
}
