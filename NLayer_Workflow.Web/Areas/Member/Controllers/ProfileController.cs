using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer_Workflow.Entities.Concrete;
using NLayer_Workflow.Web.Areas.Member.Models;

namespace NLayer_Workflow.Web.Areas.Member.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly UserManager<AppUser> userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> ProfileUpdate()
        {
            var admin = await userManager.FindByNameAsync(User.Identity.Name);

            var model = new UpdateMemberViewModel()
            {
                Id = admin.Id,
                Name = admin.Name,
                Email = admin.Email,
                Surname = admin.Surname,
                Picture = admin.Picture,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProfileUpdate(UpdateMemberViewModel model, IFormFile Resim)
        {
            var user = userManager.Users.FirstOrDefault(i => i.Id == model.Id);
            if (Resim != null)
            {
                string imgExtension = Path.GetExtension(Resim.FileName);
                string imgName = Guid.NewGuid() + imgExtension;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + imgName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await Resim.CopyToAsync(stream);
                }

                user.Picture = imgName;
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;

                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ProfileUpdate");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return RedirectToAction("");
        }

    }
}