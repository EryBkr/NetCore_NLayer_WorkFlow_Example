using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Bussiness.Abstract
{
    public interface IFileService
    {   
        /// <summary>
        /// Geriye üretmiş ve upload etmiş olduğu pdf dostasının virtual yolunu döner
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        string ExecutePdf<T>(List<T> entity) where T:class,new();

        /// <summary>
        /// Geriye excel verisini byte dizisi olarak döner
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        byte[] ExecuteExcelf<T>(List<T> entity) where T : class, new();
    }
}
