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
        public List<Work> GetAllIncludedTable()
        {
            using (var context = new MyDataContext())
            {
                var works = context.Works.Include(i => i.Urgency).Include(i => i.Reports).Include(i => i.AppUser).Where(i => i.Status == false).OrderByDescending(i => i.CreatedDate).ToList(); //Eager Loading işlemi yaptık ve ilişkili olduğu tablolarla beraber getirdik
                return works;
            }
        }

        public List<Work> GetListWorkWithUrgency()
        {
            using (var context = new MyDataContext())
            {
                var works = context.Works.Include(i => i.Urgency).Where(i => i.Status == false).OrderByDescending(i => i.CreatedDate).ToList(); //Eager Loading işlemi yaptık
                return works;
            }
        }

        public Work GetWithReportsById(int id)
        {
            using (var context = new MyDataContext())
            {
                var work = context.Works.Include(i => i.Reports).Include(i=>i.AppUser).FirstOrDefault(i => i.Id == id);
                return work;
            }
        }

        public List<Work> GetWithUser(int userId)
        {
            using (var context = new MyDataContext())
            {
                var works = context.Works.Where(i => i.AppUserId == userId).ToList();
                return works;
            }
        }


        public Work GetWorkDetailWithUrgency(int id)
        {
            using (var context = new MyDataContext())
            {
                var work = context.Works.Include(i => i.Urgency).FirstOrDefault(i => i.Status == false && i.Id == id); //Eager Loading işlemi yaptık
                return work;
            }
        }
    }
}
