﻿using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {

        List<Product> TGetProductsWithCategories();
		int TProductCount();
		int TProductCountByCategoryNameDrink();
		int TProductCountByCategoryNameHamburger();
		string TProductPriceAvg();
		string TProductNamePriceByMaxPrice();
		string TProductNamePriceByMinPrice();
		string TProductPriceByHamburger();
        string TTotalProduct();
    }
}
