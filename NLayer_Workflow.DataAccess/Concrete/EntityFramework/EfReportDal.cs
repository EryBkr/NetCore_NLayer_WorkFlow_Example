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
        public int GetUserReportCount(int userId)
        {
            using (var dB=new MyDataContext())
            {
                var result = dB.Works.Include(i => i.Reports).Where(i => i.AppUserId == userId);
                var count = result.Select(i => i.Reports).Count();
                return count;
            }
        }

        public Report GetWithWorkById(int id)
        {
            using (var dB=new MyDataContext())
            {
                var report = dB.Reports.Include(i => i.Work).ThenInclude(i=>i.Urgency).FirstOrDefault(i => i.Id == id); //Urgency Tablosu Work tablosunda yer aldığı için ThenInclude kullandık
                return report;
            }
        }

        public int TotalReportsCount()
        {
            using(var dB=new MyDataContext())
            {
                var count = dB.Reports.Count();
                return count;
            }
        }
    }
}
