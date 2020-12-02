using NLayer_Workflow.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NLayer_Workflow.Core.Bussiness.Abstract
{
    public interface IGenericService<T> where T:class,IEntity,new() //İş katmanı için generic yapı oluşturduk.Alacağı tip IEntity tarafından imzalanmış bir class olmalı diye belirttik
    {
        //Temel CRUD işlemlerimizi tanımladık
        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
