using NLayer_Workflow.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NLayer_Workflow.Core.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T:class,IEntity,new() //Dataccess için generic bir interface oluşturduk
    {
        //Temel CRUD İşlemlerini yazdık
        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
