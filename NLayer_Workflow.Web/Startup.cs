using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLayer_Workflow.Bussiness.Extensions.DIResolvers;
using NLayer_Workflow.DataAccess.Concrete.EntityFramework.Contexts;
using NLayer_Workflow.Entities.Concrete;
using NLayer_Workflow.Web.Filters;

namespace NLayer_Workflow.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(opt=> {opt.Filters.Add(typeof(GlobalModelStateValidatorAttribute)); }); //Added MVC and Global Model State Kontrol�
            services.AddContainerWithDependencies();//Dependency Injection
            services.AddDbContext<MyDataContext>();//Db Context eklendi
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<MyDataContext>();//Identity Eklendi
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();//wwwroot d��ar�ya a��ld�

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute
                (
                    name: "areas", //Area URL patternini olu�turduk
                    pattern: "{area}/{controller=Home}/{action=Index}/{id?}"
                    );

                endpoints.MapControllerRoute
                (
                    name:"default",
                    pattern:"{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
