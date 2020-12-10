using NLayer_Workflow.Core.DataAccess.EntityFramework;
using NLayer_Workflow.DataAccess.Abstract;
using NLayer_Workflow.DataAccess.Concrete.EntityFramework.Contexts;
using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLayer_Workflow.DataAccess.Concrete.EntityFramework
{
    public class EfNotificationDal : EfEntityRepositoryBase<MyDataContext, Notification>, INotificationDal //Generic yapımı ve interface'mi implemente ettim
    {
        public List<Notification> GetIsNotRead(int userId)
        {
            using (var dB=new MyDataContext())
            {
                var notifies=dB.Notifications.Where(i=>i.AppUserId==userId && i.IsRead==false).ToList();
                return notifies;
            }
        }
    }
}
