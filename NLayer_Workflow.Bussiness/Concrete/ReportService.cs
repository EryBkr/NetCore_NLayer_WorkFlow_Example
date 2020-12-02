using NLayer_Workflow.Bussiness.Abstract;
using NLayer_Workflow.DataAccess.Abstract;
using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NLayer_Workflow.Bussiness.Concrete
{
    public class ReportService : IReportService //Service interface lerimizi impelente ettik.Artık İş kodlarımızı bu kısımda yazacağız
    {
        private readonly IReportDal _reportDal;

        public ReportService(IReportDal reportDal) //DB işlemlerimiz iş katmanında kontrolden geçtikten sonra gerçekleştirilecek.Dependency Injection yöntemi ile Context'e bağlı Interface lerimizi çağırıyoruz
        {
            this._reportDal = reportDal;
        }

        public void Add(Report entity)
        {
            _reportDal.Add(entity);
        }

        public void Delete(Report entity)
        {
            _reportDal.Delete(entity);
        }

        public Report Get(Expression<Func<Report, bool>> filter = null)
        {
            var report = _reportDal.Get(filter);
            return report;
        }

        public List<Report> GetList(Expression<Func<Report, bool>> filter = null)
        {
            var reports = _reportDal.GetList(filter);
            return reports;
        }

        public void Update(Report entity)
        {
            _reportDal.Update(entity);
        }
    }
}
