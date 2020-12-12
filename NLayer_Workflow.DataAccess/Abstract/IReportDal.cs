using NLayer_Workflow.Core.DataAccess.Abstract;
using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.DataAccess.Abstract
{
    public interface IReportDal : IEntityRepository<Report> //Database ile iletişime geçecek soyut yapılarımızı oluşturduk
    {
        Report GetWithWorkById(int id);
        int GetUserReportCount(int userId);
        int TotalReportsCount();
    }
}
