using Microsoft.Extensions.DependencyInjection;
using NLayer_Workflow.DataAccess.Concrete.EntityFramework.Contexts;
using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Bussiness.Extensions.DIResolvers
{
    public static class StartupIdentityResolvers
    {
        public static void AddIdentityConfigurations(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(opt=>  //Parola Ayarları
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<MyDataContext>();//Identity Eklendi
        }
    }
}
