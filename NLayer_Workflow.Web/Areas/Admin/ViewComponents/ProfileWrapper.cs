using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayer_Workflow.Web.Areas.Admin.ViewComponents
{
    public class ProfileWrapper:ViewComponent
    {
        private readonly UserManager<AppUser> userManager;

        public ProfileWrapper(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            var user = userManager.FindByNameAsync(userName).Result;
            return View(user);
        }
    }
}
