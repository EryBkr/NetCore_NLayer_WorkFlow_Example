using Microsoft.EntityFrameworkCore;
using NLayer_Workflow.Core.DataAccess.Abstract;
using NLayer_Workflow.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NLayer_Workflow.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TContext, TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new() //Database için context nesnemizi ve tablo entity ile çalışacak generic bir sınıf oluşturduk.Burası Database işlemlerini execute edecek var diğer tablolarla ilişki içerisinde olacak
        where TContext : DbContext, new()
    {
        //Generic biçimde çalışan temel database işlemlerimizi yerine getiren metotları oluşturduk.Burada ki amaç bu metotları tekrar tekrar yazmamaktır.
        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(filter);
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList(); //filter verilemişse bütün kayıtları getirsin
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Update(entity);
                context.SaveChanges();
            }
        }
    }
}
