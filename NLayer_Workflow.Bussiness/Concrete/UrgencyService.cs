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
    public class UrgencyService : IUrgencyService //Service interface lerimizi impelente ettik.Artık İş kodlarımızı bu kısımda yazacağız
    {
        private readonly IUrgencyDal _urgencyDal;

        public UrgencyService(IUrgencyDal urgencyDal) //DB işlemlerimiz iş katmanında kontrolden geçtikten sonra gerçekleştirilecek.Dependency Injection yöntemi ile Context'e bağlı Interface lerimizi çağırıyoruz
        {
            this._urgencyDal = urgencyDal;
        }

        public void Add(Urgency entity)
        {
            _urgencyDal.Add(entity);
        }

        public void Delete(Urgency entity)
        {
            _urgencyDal.Delete(entity);
        }

        public Urgency Get(Expression<Func<Urgency, bool>> filter = null)
        {
            var urgency = _urgencyDal.Get(filter);
            return urgency;
        }

        public List<Urgency> GetList(Expression<Func<Urgency, bool>> filter = null)
        {
            var urgencies = _urgencyDal.GetList(filter).ToList();
            return urgencies;
        }

        public void Update(Urgency entity)
        {
            _urgencyDal.Update(entity);
        }
    }
}
