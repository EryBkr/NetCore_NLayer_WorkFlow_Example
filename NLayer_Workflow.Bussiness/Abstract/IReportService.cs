using NLayer_Workflow.Core.Bussiness.Abstract;
using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Bussiness.Abstract
{
    public interface IReportService : IGenericService<Report>
    {
        Report GetWithWorkById(int id);
        int GetUserReportCount(int userId);
        int TotalReportsCount();
    }
}
