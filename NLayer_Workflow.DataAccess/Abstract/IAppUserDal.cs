using NLayer_Workflow.Core.DataAccess.Abstract;
using NLayer_Workflow.Entities.Concrete;
using NLayer_Workflow.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.DataAccess.Abstract
{
    public interface IAppUserDal
    {
        List<AppUser> GetListWithoutAdmin();
        List<AppUser> GetListWithoutAdminInPagination(out int totalPage,string search,int activePage=1); //Sayfalama yapacağız
        List<GetUsersCompletedWorkCount> GetUsersWorkCount(bool IsFinish); //Kullanıcıların iş sayısı
    }
}
