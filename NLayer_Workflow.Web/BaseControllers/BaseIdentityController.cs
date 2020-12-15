using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayer_Workflow.Web.BaseControllers
{
    public class BaseIdentityController:Controller
    {
        protected readonly UserManager<AppUser> userManager;
        public BaseIdentityController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        protected async Task<AppUser> GetLogInUser() //Sürekli DI aracılığıyla diğer controllerde giriş yapmış kullanıcıyı çağırmamak için merkezi bir operasyon yazdık
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            return user;
        }

        protected void ModelStateAddErrors(IEnumerable<IdentityError> errors) //Modelstate ' e hataları merkezi bir yerde ekliyoruz
        {
            foreach (var item in errors)
            {
                ModelState.AddModelError("", item.Description);
            }
        }
    }
}
