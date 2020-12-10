using NLayer_Workflow.Core.DataAccess.Abstract;
using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.DataAccess.Abstract
{
    public interface INotificationDal : IEntityRepository<Notification> //Database ile iletişime geçecek soyut yapılarımızı oluşturduk
    {
    }
}
