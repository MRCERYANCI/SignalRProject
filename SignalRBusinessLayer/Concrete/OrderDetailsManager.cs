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
	public class OrderDetailsManager : IOrderDetailsService
	{
		private readonly IOrderDetailsDal _orderDetailsDal;

		public OrderDetailsManager(IOrderDetailsDal orderDetailsDal)
		{
			_orderDetailsDal = orderDetailsDal;
		}

		public void TAdd(OrderDetail entity)
		{
			_orderDetailsDal.Add(entity);
		}

		public void TDelete(OrderDetail entity)
		{
			_orderDetailsDal.Delete(entity);
		}

		public List<OrderDetail> TGetAll()
		{
			return _orderDetailsDal.GetAll();
		}

		public OrderDetail TGetById(int id)
		{
			return _orderDetailsDal.GetById(id);
		}

		public List<OrderDetail> TLinqList(Expression<Func<OrderDetail, bool>> filter)
		{
			return _orderDetailsDal.LinqList(filter);
		}

		public OrderDetail TLinqListGet(Expression<Func<OrderDetail, bool>> filter)
		{
			return _orderDetailsDal.LinqListGet(filter);
		}

		public void TUpdate(OrderDetail entity)
		{
			_orderDetailsDal.Update(entity);
		}
	}
}
