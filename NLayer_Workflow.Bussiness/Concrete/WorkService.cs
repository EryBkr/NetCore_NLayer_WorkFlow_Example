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
    public class WorkService : IWorkService //Service interface lerimizi impelente ettik.Artık İş kodlarımızı bu kısımda yazacağız
    {

        private readonly IWorkDal _workDal;

        public WorkService(IWorkDal _workDal) //DB işlemlerimiz iş katmanında kontrolden geçtikten sonra gerçekleştirilecek.Dependency Injection yöntemi ile Context'e bağlı Interface lerimizi çağırıyoruz
        {
            this._workDal = _workDal;
        }

        public void Add(Work entity)
        {
            _workDal.Add(entity);
        }

        public void Delete(Work entity)
        {
            _workDal.Delete(entity);
        }

        public Work Get(Expression<Func<Work, bool>> filter = null)
        {
            var work=_workDal.Get(filter);
            return work;
        }

        public List<Work> GetList(Expression<Func<Work, bool>> filter = null)
        {
            var works = _workDal.GetList(filter);
            return works;
        }

        public List<Work> GetListWorkWithUrgency()
        {
            var works = _workDal.GetListWorkWithUrgency();
            return works;
        }

        public void Update(Work entity)
        {
            _workDal.Update(entity);
        }
    }
}
