using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer_Workflow.Bussiness.Abstract;
using NLayer_Workflow.Entities.Concrete;
using NLayer_Workflow.Web.Models;

namespace NLayer_Workflow.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public HomeController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LoginModel model)
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

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AppUserAddViewModel model) //Kullanıcı kayıt olunca otomatik olarak Member olarak atanacak
        {
            var user = new AppUser {
                UserName = model.UserName,
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname
            };
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
                    foreach (var item in roleResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                

            }
            return View(model);
        }
    }
}