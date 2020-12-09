using Microsoft.EntityFrameworkCore;
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
    public class EfReportDal : EfEntityRepositoryBase<MyDataContext, Report>, IReportDal //Generic yapımı ve interface'mi implemente ettim
    {
        public Report GetWithWorkById(int id)
        {
            using (var dB=new MyDataContext())
            {
                var report = dB.Reports.Include(i => i.Work).ThenInclude(i=>i.Urgency).FirstOrDefault(i => i.Id == id); //Urgency Tablosu Work tablosunda yer aldığı için ThenInclude kullandık
                return report;
            }
        }
    }
}
