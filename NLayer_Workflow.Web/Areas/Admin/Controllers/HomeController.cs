using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer_Workflow.Bussiness.Abstract;
using NLayer_Workflow.Entities.Concrete;
using NLayer_Workflow.Web.Areas.Admin.Models;
using NLayer_Workflow.Web.BaseControllers;

namespace NLayer_Workflow.Web.Areas.Admin.Controllers
{
   
    public class HomeController : BaseAdminIdentityController
    {
        private readonly IWorkService workService;
        private readonly INotificationService notificationService;
        private readonly IReportService reportService;

        public HomeController(IWorkService workService, INotificationService notificationService,UserManager<AppUser> userManager,IReportService reportService):base(userManager)
        {
            this.workService = workService;
            this.notificationService = notificationService;
            this.reportService = reportService;
        }
       
        public async Task<IActionResult> Index()
        {
            var user = await GetLogInUser(); //Kalıtım aldığımız sınıftan direkt giriş yapmış kullanıcıyı aldık
            var model = new GetStatisticsModel();
            model.NotAttachWorkCount = workService.NotAttachWorks();
            model.CompletedWorksCount = workService.CompletedWorksCount();
            model.IsNotReadNotifiesCount = notificationService.GetIsNotReadCount(user.Id);
            model.TotalReportCount = reportService.TotalReportsCount();

            return View(model);
        }
    }
}