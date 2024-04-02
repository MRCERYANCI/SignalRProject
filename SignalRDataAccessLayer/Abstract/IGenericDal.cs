using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class  //İmzalar Tutalacak
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        List<T> GetAll();
        T GetById(int id);
        List<T> LinqList(Expression<Func<T, bool>> filter);
        T LinqListGet(Expression<Func<T, bool>> filter);
    }
}
