using NLayer_Workflow.Bussiness.Abstract;
using NLayer_Workflow.Core.Bussiness.CustomLogger;
using NLayer_Workflow.DataAccess.Abstract;
using NLayer_Workflow.Entities.Concrete;
using NLayer_Workflow.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Bussiness.Concrete
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserDal appUserDal;

        public AppUserService(IAppUserDal appUserDal, ICustomLogger customLogger)
        {
            this.appUserDal = appUserDal;
        }

        public List<AppUser> GetListWithoutAdmin()
        {
            var users = appUserDal.GetListWithoutAdmin();
            return users;
        }

        public List<GetUsersCompletedWorkCount> GetUsersWorkCount(bool IsFinish)
        {
            var users = appUserDal.GetUsersWorkCount(IsFinish);
            return users;
        }

        List<AppUser> IAppUserService.GetListWithoutAdminInPagination(out int totalPage, string search, int activePage)
        {
            var users = appUserDal.GetListWithoutAdminInPagination(out totalPage, search, activePage);
            return users;
        }
    }
}
