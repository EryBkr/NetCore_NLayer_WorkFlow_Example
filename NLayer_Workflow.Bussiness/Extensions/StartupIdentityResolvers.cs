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
            services.AddIdentity<AppUser, AppRole>(opt =>  //Parola Ayarları
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<MyDataContext>();//Identity Eklendi
        }

        public static void CookieConfigurations(this IServiceCollection services,string loginPath) //Cookie ayarları
        {
            services.ConfigureApplicationCookie(opt=> 
            {
                opt.Cookie.Name = "WorkFlowCookie";
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict; //Başka sitelerle paylaşımı
                opt.Cookie.HttpOnly = true; //JS Erişimi
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
                opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest; //HTTP OR HTTPS
                opt.LoginPath = loginPath;
            });
        }

    }
}
