using SignalRDataAccessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly SignalRContext _signalRContext;

        public GenericRepository(SignalRContext signalRContext)
        {
            _signalRContext = signalRContext;
        }

        public void Add(T entity)
        {
            _signalRContext.Add(entity);
            _signalRContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _signalRContext.Remove(entity);
            _signalRContext.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _signalRContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _signalRContext.Set<T>().Find(id); //Null Dönme İhimali Olduğu İçin
        }

        public List<T> LinqList(Expression<Func<T, bool>> filter)
        {
            return _signalRContext.Set<T>().Where(filter).ToList();
        }

        public T LinqListGet(Expression<Func<T, bool>> filter)
        {
            return _signalRContext.Set<T>().Where(filter).FirstOrDefault();
        }

        public void Update(T entity)
        {
            _signalRContext.Update(entity);
            _signalRContext.SaveChanges();
        }
    }
}
