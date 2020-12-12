using NLayer_Workflow.Bussiness.Abstract;
using NLayer_Workflow.DataAccess.Abstract;
using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NLayer_Workflow.Bussiness.Concrete
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationDal notificationDal;

        public NotificationService(INotificationDal notificationDal)
        {
            this.notificationDal = notificationDal;
        }

        public void Add(Notification entity)
        {
            notificationDal.Add(entity);
        }

        public void Delete(Notification entity)
        {
            notificationDal.Delete(entity);
        }

        public Notification Get(Expression<Func<Notification, bool>> filter = null)
        {
            var notify = notificationDal.Get(filter);
            return notify;
        }

        public List<Notification> GetIsNotRead(int userId)
        {
            var notifies = notificationDal.GetIsNotRead(userId);
            return notifies;
        }

        public int GetIsNotReadCount(int userId)
        {
            var count = notificationDal.GetIsNotReadCount(userId);
            return count;
        }

        public List<Notification> GetList(Expression<Func<Notification, bool>> filter = null)
        {
            var notifies = notificationDal.GetList(filter);
            return notifies;
        }

        public void Update(Notification entity)
        {
            notificationDal.Update(entity);
        }
    }
}
