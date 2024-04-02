using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TAdd(T entity);
        void TDelete(T entity);
        void TUpdate(T entity);
        List<T> TGetAll();
        T TGetById(int id);
        List<T> TLinqList(Expression<Func<T, bool>> filter);
        T TLinqListGet(Expression<Func<T, bool>> filter);
    }
}
