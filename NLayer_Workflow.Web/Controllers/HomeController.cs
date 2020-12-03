using System;
using System.Collections.Generic;
using System.Linq;
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

        public HomeController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogIn(LoginModel model)
        {
            return View();
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