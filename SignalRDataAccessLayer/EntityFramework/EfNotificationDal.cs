using SignalRDataAccessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalRDataAccessLayer.Repositories;
using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDataAccessLayer.EntityFramework
{
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EfNotificationDal(SignalRContext signalRContext) : base(signalRContext)
        {
        }

        public int NotificatinCountByStatus(bool Status = false)
        {
            using (var context = new SignalRContext())
            {
                return context.Notifications.Count(x => x.NotificationStatus == Status);
            }
        }

        public void NotificationChangeToTrue(int NotificationId)
        {
            using(var context = new SignalRContext())
            {
                var values = context.Notifications.Find(NotificationId);
                if(values != null)
                {
                    if(values.NotificationStatus == false)
                        values.NotificationStatus = true;
                    else
                        values.NotificationStatus = false;

                    context.Notifications.Update(values);
                    context.SaveChanges();
                }
            }
        }
    }
}
