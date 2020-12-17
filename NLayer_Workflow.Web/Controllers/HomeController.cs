using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer_Workflow.Bussiness.Abstract;
using NLayer_Workflow.Core.Bussiness.CustomLogger;
using NLayer_Workflow.Entities.Concrete;
using NLayer_Workflow.Entities.DTO.AppUserDTO;
using NLayer_Workflow.Web.BaseControllers;

namespace NLayer_Workflow.Web.Controllers
{
    public class HomeController : BaseIdentityController
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly IAutoMapperService mapper;
        private readonly ICustomLogger customLogger;

        public HomeController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager, IAutoMapperService mapper, ICustomLogger customLogger) :base(userManager)
        {
            this.signInManager = signInManager;
            this.mapper = mapper;
            this.customLogger = customLogger;
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(UserSignInDto model)
        {
            var user=await userManager.FindByNameAsync(model.UserName);
            if (user!=null)
            {
                var result=await signInManager.PasswordSignInAsync(user.UserName,model.Password,model.RememberMe,false);
                if (result.Succeeded)
                {
                    var roles=await userManager.GetRolesAsync(user); //Kullanıcının rolleri alındı
                    if (roles.Contains("Admin"))
                        return RedirectToAction("Index", "Home", new { area = "Admin" }); //Admin rolü varsa admin area ya yönlendirdik
                    else
                        return RedirectToAction("Index", "Home", new { area = "Member" }); //Yoksa Member Area ya yönlendirdik
                }
            }
            else
            {
                ModelState.AddModelError("","Kullanıcı Adı veya Şifre Hatalı"); //Suistimal edilmemesi için ifadeyi geniş yazdık
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserAddDto model) //Kullanıcı kayıt olunca otomatik olarak Member olarak atanacak
        {
            var user = mapper.Mapper.Map<AppUser>(model);
            var result=await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var roleResult = await userManager.AddToRoleAsync(user, "Member");
                if (roleResult.Succeeded)
                {
                    return RedirectToAction("LogIn");
                }
                else
                {
                    ModelStateAddErrors(result.Errors); //Hata ekleme mekanizmasınız merkezi hale getirdik
                }
            }
            else
            {
                ModelStateAddErrors(result.Errors);
            }
            return View(model);
        }

        public async  Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("LogIn");
        }

        //Custom Status Code Page
        public IActionResult StatusCode(int? code)
        {
            if (code==404)
            {
                ViewBag.Code = code;
                ViewBag.Message = "Sayfa bulunamadı";
            }
            
            return View();
        }

        //Global olarak hatayı ele aldık
        public IActionResult Error()
        {
            var exceptionHandlerPathFeature =
        HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            customLogger.Log($"Hatanın oluştuğu yer: {exceptionHandlerPathFeature.Path} \n Hata Mesajı:{exceptionHandlerPathFeature.Error.Message}\n " +
                $"StackTrace:{exceptionHandlerPathFeature.Error.StackTrace}");

            ViewBag.Path=exceptionHandlerPathFeature.Path;
            ViewBag.Message = exceptionHandlerPathFeature.Error.Message;
            return View();
        }
    }
}