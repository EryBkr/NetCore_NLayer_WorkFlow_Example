using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer_Workflow.Bussiness.Abstract;
using NLayer_Workflow.Entities.Concrete;
using NLayer_Workflow.Web.Areas.Member.Models;
using NLayer_Workflow.Web.BaseControllers;

namespace NLayer_Workflow.Web.Areas.Member.Controllers
{

    public class HomeController : BaseMemberIdentityController
    {
        private readonly IReportService reportService;
        private readonly IWorkService workService;
        private readonly INotificationService notificationService;

        public HomeController(IReportService reportService, UserManager<AppUser> userManager, IWorkService workService, INotificationService notificationService):base(userManager)
        {
            this.reportService = reportService;
            this.workService = workService;
            this.notificationService = notificationService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await GetLogInUser();

            var count = reportService.GetUserReportCount(user.Id);
            var workCount = workService.GetUserWorkCount(user.Id);
            var notifyCount = notificationService.GetIsNotReadCount(user.Id);
            var needsWork = workService.NeedCompleteUserWork(user.Id);

            var model = new GetStatisticsModel();
            model.ReportCount = count;
            model.WorkCount = workCount;
            model.NotifyCount = notifyCount;
            model.NeedCompleteWorksCount = needsWork;

            return View(model);
        }
    }
}