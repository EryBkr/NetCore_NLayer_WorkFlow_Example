using Microsoft.Extensions.DependencyInjection;
using NLayer_Workflow.Bussiness.Abstract;
using NLayer_Workflow.Bussiness.Concrete;
using NLayer_Workflow.DataAccess.Abstract;
using NLayer_Workflow.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Bussiness.Extensions.DIResolvers
{
    public static class StartupDIResolvers
    {
        public static void AddContainerWithDependencies(this IServiceCollection services)
        {
            //Dependency Injection
            services.AddScoped<IWorkService, WorkService>();
            services.AddScoped<IWorkDal, EfWorkDal>();

            services.AddScoped<IUrgencyService, UrgencyService>();
            services.AddScoped<IUrgencyDal, EfUrgencyDal>();

            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IReportDal, EfReportDal>();

            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IAppUserDal, EfUserDal>();
        }
    }
}
