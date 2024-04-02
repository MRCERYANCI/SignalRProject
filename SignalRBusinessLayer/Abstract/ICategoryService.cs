using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
		public int TCategoryCount();
		public int TAciveCategoryCount();
		public int TpasiveCategoryCount();
	}
}
