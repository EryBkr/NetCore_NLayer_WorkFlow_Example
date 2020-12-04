using NLayer_Workflow.Bussiness.Abstract;
using NLayer_Workflow.DataAccess.Abstract;
using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Bussiness.Concrete
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserDal appUserDal;

        public AppUserService(IAppUserDal appUserDal)
        {
            this.appUserDal = appUserDal;
        }

        public List<AppUser> GetListWithoutAdmin()
        {
            var users = appUserDal.GetListWithoutAdmin();
            return users;
        }
    }
}
