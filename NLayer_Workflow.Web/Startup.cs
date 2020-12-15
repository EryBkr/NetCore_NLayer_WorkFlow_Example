using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLayer_Workflow.Bussiness.Extensions;
using NLayer_Workflow.Bussiness.Extensions.DIResolvers;
using NLayer_Workflow.Bussiness.ValidationRules.FluentValidation.AppUser;
using NLayer_Workflow.Bussiness.ValidationRules.FluentValidation.Report;
using NLayer_Workflow.Bussiness.ValidationRules.FluentValidation.Urgency;
using NLayer_Workflow.Bussiness.ValidationRules.FluentValidation.Work;
using NLayer_Workflow.DataAccess.Concrete.EntityFramework.Contexts;
using NLayer_Workflow.Entities.Concrete;
using NLayer_Workflow.Entities.DTO.AppUserDTO;
using NLayer_Workflow.Entities.DTO.ReportDTO;
using NLayer_Workflow.Entities.DTO.UrgencyDTO;
using NLayer_Workflow.Entities.DTO.WorkDTO;
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
            services.AddControllersWithViews(opt => { opt.Filters.Add(typeof(GlobalModelStateValidatorAttribute)); }).AddFluentValidation(); //Added MVC and Global Model State Kontrol� ve Fluent Validation Eklendi

            services.AddContainerWithDependencies();//Dependency Injection Custom olarak eklendi
            services.AddDbContext<MyDataContext>();//Db Context eklendi
            services.AddIdentityConfigurations();//Identity Custom olarak eklendi
            services.CookieConfigurations("/Home/LogIn"); //Cookie Ayar� ve login path bilgisi verildi

            services.AddAutoMapper(typeof(Startup));//Dependency Injection kullanabilmek i�in tan�mlad�k

            //Validasyon Kontrol�
            services.ValidatorConfigurations();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage(); 
                app.UseExceptionHandler("/Home/Error"); //Global olarak hatay� ele ald�k,Normalde Product ortam�nda tan�mlanmas� gerekiyor
            }

            IdentityInitilaizer.SeedData(userManager, roleManager).Wait();//Seed Data s�n�f�m�z uyguland�.Wait metodumuz async metodumuzu �al��t�rmam�z� sa�lad�


            app.UseStatusCodePagesWithReExecute("/Home/StatusCode","?code={0}"); //Custom Status Code Page

            app.UseRouting();
            //Uyelik ve yetkilendirme
            app.UseAuthentication();
            app.UseAuthorization();

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
                    name: "default",
                    pattern: "{controller=Home}/{action=LogIn}/{id?}"
                    );
            });
        }
    }
}
