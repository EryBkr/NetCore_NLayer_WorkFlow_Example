using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer_Workflow.Bussiness.Abstract;
using NLayer_Workflow.Entities.Concrete;

namespace NLayer_Workflow.Web.Areas.Member.Controllers
{
    public class NotificationController : BaseController
    {
        private readonly INotificationService notificationService;
        private readonly UserManager<AppUser> userManager;

       public NotificationController(INotificationService notificationService, UserManager<AppUser> userManager)
        {
            this.notificationService = notificationService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var notifies = notificationService.GetList(i=>i.AppUserId==user.Id);
            return View(notifies);
        }

        public IActionResult Read(int id)
        {
            var notify = notificationService.Get(i => i.Id == id);
            notify.IsRead = true;
            notificationService.Update(notify);
            return RedirectToAction("Index");
        }
    }
}