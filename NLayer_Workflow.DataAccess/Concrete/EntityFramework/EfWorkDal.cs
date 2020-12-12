using Microsoft.EntityFrameworkCore;
using NLayer_Workflow.Core.DataAccess.EntityFramework;
using NLayer_Workflow.DataAccess.Abstract;
using NLayer_Workflow.DataAccess.Concrete.EntityFramework.Contexts;
using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Linq.Expressions;

namespace NLayer_Workflow.DataAccess.Concrete.EntityFramework
{
    public class EfWorkDal : EfEntityRepositoryBase<MyDataContext, Work>, IWorkDal //Generic yapımı ve interface'mi implemente ettim
    {
        public int CompletedWorksCount()
        {
            using(var dB=new MyDataContext())
            {
                var count = dB.Works.Where(i => i.Status == true).Count();
                return count;
            }
        }

        public List<Work> GetAllIncludedTable()
        {
            using (var context = new MyDataContext())
            {
                var works = context.Works.Include(i => i.Urgency).Include(i => i.Reports).Include(i => i.AppUser).Where(i => i.Status == false).OrderByDescending(i => i.CreatedDate).ToList(); //Eager Loading işlemi yaptık ve ilişkili olduğu tablolarla beraber getirdik
                return works;
            }
        }

        public List<Work> GetAllIncludedTable(Expression<Func<Work, bool>> filter)
        {
            using (var context = new MyDataContext())
            {
                var works = context.Works.Include(i => i.Urgency).Include(i => i.Reports).Include(i => i.AppUser).Where(filter).OrderByDescending(i => i.CreatedDate).ToList(); //Eager Loading işlemi yaptık ve ilişkili olduğu tablolarla beraber getirdik
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

        public int GetUserWorkCount(int userId)
        {
            using (var dB=new MyDataContext())
            {
                var workCount = dB.Works.Where(i => i.AppUserId == userId).Count();
                return workCount;
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

        public List<Work> GetWorksWithPagination(out int totalPage,int activePage, int userId)
        {
            using (var context = new MyDataContext())
            {
                var works = context.Works.Include(i => i.Urgency).Include(i => i.Reports).Include(i => i.AppUser)
                    .Where(i => i.Status == true && i.AppUserId == userId); //Eager Loading işlemi yaptık ve ilişkili olduğu tablolarla beraber getirdik

                totalPage = (int)Math.Ceiling((double)works.Count() / 3);

                works=works.OrderByDescending(i => i.CreatedDate).Skip((activePage - 1) * 3).Take(3);

                return works.ToList();
            }
        }

        public int NeedCompleteUserWork(int userId)
        {
            using (var dB=new MyDataContext())
            {
                var count = dB.Works.Where(i => i.AppUserId == userId && i.Status == false).Count();
                return count;
            }
        }

        public int NotAttachWorks()
        {
            using(var dB=new MyDataContext())
            {
                var count = dB.Works.Where(i => i.AppUserId == null).Count();
                return count;
            }
        }
    }
}
