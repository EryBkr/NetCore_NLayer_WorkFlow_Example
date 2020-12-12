using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer_Workflow.Bussiness.Abstract;
using NLayer_Workflow.Entities.Concrete;
using NLayer_Workflow.Web.Areas.Admin.Models;

namespace NLayer_Workflow.Web.Areas.Admin.Controllers
{
   
    public class HomeController : BaseController
    {
        private readonly IWorkService workService;
        private readonly INotificationService notificationService;
        private readonly UserManager<AppUser> userManager;
        private readonly IReportService reportService;

        public HomeController(IWorkService workService, INotificationService notificationService,UserManager<AppUser> userManager,IReportService reportService)
        {
            this.workService = workService;
            this.notificationService = notificationService;
            this.userManager = userManager;
            this.reportService = reportService;
        }
       
        public async Task<IActionResult> Index()
        {
            var userName = User.Identity.Name;
            var user = await userManager.FindByNameAsync(userName);

            var model = new GetStatisticsModel();
            model.NotAttachWorkCount = workService.NotAttachWorks();
            model.CompletedWorksCount = workService.CompletedWorksCount();
            model.IsNotReadNotifiesCount = notificationService.GetIsNotReadCount(user.Id);
            model.TotalReportCount = reportService.TotalReportsCount();

            return View(model);
        }
    }
}