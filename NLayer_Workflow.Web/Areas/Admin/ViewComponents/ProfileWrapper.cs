using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer_Workflow.Bussiness.Abstract;
using NLayer_Workflow.Entities.Concrete;
using NLayer_Workflow.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayer_Workflow.Web.Areas.Admin.ViewComponents
{
    public class ProfileWrapper:ViewComponent
    {
        private readonly UserManager<AppUser> userManager;
        private readonly INotificationService notificationService;

        public ProfileWrapper(UserManager<AppUser> userManager, INotificationService notificationService)
        {
            this.userManager = userManager;
            this.notificationService = notificationService;
        }

        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            var user = userManager.FindByNameAsync(userName).Result;

            var isNotReadCount = notificationService.GetIsNotRead(user.Id).Count();

            var model = new SideBarComponentModel() {AppUser=user,NotifyCount=isNotReadCount};
            return View(model);
        }
    }
}
