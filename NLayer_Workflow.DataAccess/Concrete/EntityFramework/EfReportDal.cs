﻿using NLayer_Workflow.Core.DataAccess.EntityFramework;
using NLayer_Workflow.DataAccess.Abstract;
using NLayer_Workflow.DataAccess.Concrete.EntityFramework.Contexts;
using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.DataAccess.Concrete.EntityFramework
{
    public class EfReportDal : EfEntityRepositoryBase<MyDataContext, Report>, IReportDal //Generic yapımı ve interface'mi implemente ettim
    {
    }
}
