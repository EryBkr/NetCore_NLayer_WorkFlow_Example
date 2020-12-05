﻿using NLayer_Workflow.Core.Bussiness.Abstract;
using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Bussiness.Abstract
{
    public interface IAppUserService
    {
        List<AppUser> GetListWithoutAdmin();
        List<AppUser> GetListWithoutAdminInPagination(out int totalPage, string search, int activePage = 1);
    }
}
