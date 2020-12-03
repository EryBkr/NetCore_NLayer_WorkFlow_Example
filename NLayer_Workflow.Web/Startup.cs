using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLayer_Workflow.Bussiness.Extensions.DIResolvers;
using NLayer_Workflow.DataAccess.Concrete.EntityFramework.Contexts;
using NLayer_Workflow.Entities.Concrete;
using NLayer_Workflow.Web.Filters;
using NLayer_Workflow.Web.Functions;

namespace NLayer_Workflow.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(opt=> {opt.Filters.Add(typeof(GlobalModelStateValidatorAttribute)); }); //Added MVC and Global Model State Kontrolü
            services.AddContainerWithDependencies();//Dependency Injection Custom olarak eklendi
            services.AddDbContext<MyDataContext>();//Db Context eklendi
            services.AddIdentityConfigurations();//Identity Custom olarak eklendi
            services.CookieConfigurations("/Home/Index"); //Cookie Ayarý ve login path bilgisi verildi
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            IdentityInitilaizer.SeedData(userManager,roleManager).Wait();//Seed Data sýnýfýmýz uygulandý.Wait metodumuz async metodumuzu çalýþtýrmamýzý saðladý

            app.UseRouting();
            app.UseStaticFiles();//wwwroot dýþarýya açýldý


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute
                (
                    name: "areas", //Area URL patternini oluþturduk
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
