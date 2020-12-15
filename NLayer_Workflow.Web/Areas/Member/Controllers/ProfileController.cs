using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer_Workflow.Entities.Concrete;
using NLayer_Workflow.Entities.DTO.AppUserDTO;
using NLayer_Workflow.Web.BaseControllers;

namespace NLayer_Workflow.Web.Areas.Member.Controllers
{
    public class ProfileController : BaseMemberIdentityController
    {
        private readonly IMapper mapper;

        public ProfileController(UserManager<AppUser> userManager, IMapper mapper):base(userManager)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ProfileUpdate()
        {
            var admin = await GetLogInUser();
            var model = mapper.Map<UserUpdateDto>(admin);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProfileUpdate(UserUpdateDto model, IFormFile Resim)
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
                    ModelStateAddErrors(result.Errors);
                }
            }
            return RedirectToAction("");
        }

    }
}