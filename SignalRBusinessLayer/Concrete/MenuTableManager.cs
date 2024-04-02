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
	public class MenuTableManager : IMenuTableService
	{
		private readonly IMenuTableDal _menuTableDal;

		public MenuTableManager(IMenuTableDal menuTableDal)
		{
			_menuTableDal = menuTableDal;
		}

		public void TAdd(MenuTable entity)
		{
			_menuTableDal.Add(entity);
		}

		public void TDelete(MenuTable entity)
		{
			_menuTableDal.Delete(entity);
		}

		public List<MenuTable> TGetAll()
		{
			return _menuTableDal.GetAll();
		}

		public MenuTable TGetById(int id)
		{
			return _menuTableDal.GetById(id);
		}

		public List<MenuTable> TLinqList(Expression<Func<MenuTable, bool>> filter)
		{
			return _menuTableDal.LinqList(filter);
		}

		public MenuTable TLinqListGet(Expression<Func<MenuTable, bool>> filter)
		{
			return _menuTableDal.LinqListGet(filter);
		}

		public int TMenuTableCount()
		{
			return _menuTableDal.MenuTableCount();
		}

		public void TUpdate(MenuTable entity)
		{
			_menuTableDal.Update(entity);
		}
	}
}
