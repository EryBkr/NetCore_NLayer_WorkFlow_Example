using NLayer_Workflow.Core.Bussiness.Abstract;
using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Bussiness.Abstract
{
    public interface IWorkService : IGenericService<Work>
    {
        List<Work> GetListWorkWithUrgency();
        List<Work> GetAllIncludedTable();
        Work GetWorkDetailWithUrgency(int id);
        List<Work> GetWithUser(int userId);
    }
}
