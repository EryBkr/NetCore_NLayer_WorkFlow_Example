using NLayer_Workflow.Core.Bussiness.Abstract;
using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Bussiness.Abstract
{
    public interface INotificationService : IGenericService<Notification>
    {
        List<Notification> GetIsNotRead(int userId);
        int GetIsNotReadCount(int userId);
    }
}
