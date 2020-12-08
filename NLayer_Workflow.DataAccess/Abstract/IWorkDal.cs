using NLayer_Workflow.Core.DataAccess.Abstract;
using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NLayer_Workflow.DataAccess.Abstract
{
    public interface IWorkDal : IEntityRepository<Work> //Database ile iletişime geçecek soyut yapılarımızı oluşturduk
    {
        List<Work> GetListWorkWithUrgency();
        List<Work> GetAllIncludedTable();
        List<Work> GetAllIncludedTable(Expression<Func<Work,bool>> filter);
        Work GetWorkDetailWithUrgency(int id);
        List<Work> GetWithUser(int userId);
        Work GetWithReportsById(int id);
    }
}
