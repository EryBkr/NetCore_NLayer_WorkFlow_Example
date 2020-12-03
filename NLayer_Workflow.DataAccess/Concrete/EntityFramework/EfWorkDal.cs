using Microsoft.EntityFrameworkCore;
using NLayer_Workflow.Core.DataAccess.EntityFramework;
using NLayer_Workflow.DataAccess.Abstract;
using NLayer_Workflow.DataAccess.Concrete.EntityFramework.Contexts;
using NLayer_Workflow.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace NLayer_Workflow.DataAccess.Concrete.EntityFramework
{
    public class EfWorkDal : EfEntityRepositoryBase<MyDataContext, Work>, IWorkDal //Generic yapımı ve interface'mi implemente ettim
    {
        public List<Work> GetListWorkWithUrgency()
        {
            using (var context=new MyDataContext())
            {
                var works=context.Works.Include(i => i.Urgency).Where(i => i.Status == false).OrderByDescending(i => i.CreatedDate).ToList(); //Eager Loading işlemi yaptık
                return works;
            }
        }
    }
}
