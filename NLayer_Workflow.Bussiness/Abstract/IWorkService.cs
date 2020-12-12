using NLayer_Workflow.Core.Bussiness.Abstract;
using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NLayer_Workflow.Bussiness.Abstract
{
    public interface IWorkService : IGenericService<Work>
    {
        List<Work> GetListWorkWithUrgency();
        List<Work> GetAllIncludedTable();
        Work GetWorkDetailWithUrgency(int id);
        List<Work> GetWithUser(int userId);
        Work GetWithReportsById(int id);
        public List<Work> GetAllIncludedTable(Expression<Func<Work, bool>> filter);
        List<Work> GetWorksWithPagination(out int totalPage, int userId,int activePage=1);
        int GetUserWorkCount(int userId);
        int NeedCompleteUserWork(int userId);
        int NotAttachWorks();
        int CompletedWorksCount();
    }
}
