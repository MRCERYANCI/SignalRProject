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
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public int NotificatinCountByStatus(bool Status = false)
        {
            return _notificationDal.NotificatinCountByStatus(Status);
        }

        public void TAdd(Notification entity)
        {
            _notificationDal.Add(entity);
        }

        public void TDelete(Notification entity)
        {
            _notificationDal.Delete(entity);
        }

        public List<Notification> TGetAll()
        {
            return _notificationDal.GetAll();
        }

        public Notification TGetById(int id)
        {
            return _notificationDal.GetById(id);
        }

        public List<Notification> TLinqList(Expression<Func<Notification, bool>> filter)
        {
            return _notificationDal.LinqList(filter);
        }

        public Notification TLinqListGet(Expression<Func<Notification, bool>> filter)
        {
            return _notificationDal.LinqListGet(filter);
        }

        public void TNotificationChangeToTrue(int NotificationId)
        {
            _notificationDal.NotificationChangeToTrue(NotificationId);
        }

        public void TUpdate(Notification entity)
        {
           _notificationDal.Update(entity);
        }
    }
}
