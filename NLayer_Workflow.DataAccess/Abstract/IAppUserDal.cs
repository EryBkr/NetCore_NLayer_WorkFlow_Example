using NLayer_Workflow.Core.DataAccess.Abstract;
using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.DataAccess.Abstract
{
    public interface IAppUserDal
    {
        List<AppUser> GetListWithoutAdmin();
    }
}
