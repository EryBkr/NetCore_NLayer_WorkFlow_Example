using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer_Workflow.Bussiness.Abstract;
using NLayer_Workflow.Entities.Concrete;
using NLayer_Workflow.Web.Areas.Member.Models;

namespace NLayer_Workflow.Web.Areas.Member.Controllers
{
    public class WorkRulesController : BaseController
    {
        private readonly IWorkService workService;
        private readonly UserManager<AppUser> userManager;
        private readonly IReportService reportService;
        private readonly INotificationService notificationService;

        public WorkRulesController(IWorkService workService, UserManager<AppUser> userManager,IReportService reportService, INotificationService notificationService)
        {
            this.workService = workService;
            this.userManager = userManager;
            this.reportService = reportService;
            this.notificationService = notificationService;
        }

        public async Task<IActionResult> Index()
        {
            var userName = User.Identity.Name;
            var user =await userManager.FindByNameAsync(userName);
            var id = user.Id;
            var works = workService.GetAllIncludedTable(i => i.AppUserId == id && !i.Status);
            var models = new List<GetWorkListAllModel>();
            foreach (var item in works)
            {
                models.Add(new GetWorkListAllModel
                {
                    Id = item.Id,
                    AppUser = item.AppUser,
                    CreatedDate = item.CreatedDate,
                    Description = item.Description,
                    Name = item.Name,
                    Reports = item.Reports,
                    Urgency = item.Urgency
                });

            }

            return View(models);
        }

        [HttpGet]
        public IActionResult AddReport(int id)
        {
            var work = workService.Get(i=>i.Id==id);
            var model = new AddReportViewModel { WorkId = work.Id,WorkName=work.Name };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReport(AddReportViewModel model)
        {
            var report = new Report { WorkId = model.WorkId, Detail = model.Detail, Description = model.Description };
            reportService.Add(report);

            var adminUserList =await userManager.GetUsersInRoleAsync("Admin"); //Adminleri aldık
            var activeUser = await userManager.FindByNameAsync(User.Identity.Name); //Kullanıcıyı aldık

            foreach (var admin in adminUserList)
            {
                notificationService.Add(new Notification 
                {
                    Description = $"{activeUser.Name} {activeUser.Surname} yeni bir repor yazdı",
                    IsRead=false,
                    AppUserId=admin.Id
                });
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateReport(int id)
        {
            var report = reportService.GetWithWorkById(id);
            var model = new UpdateReportViewModel();

            model.Id = report.Id;
            model.Description = report.Description;
            model.Detail = report.Detail;
            model.WorkId = report.WorkId;
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateReport(UpdateReportViewModel model)
        {
            reportService.Update(new Report {Detail=model.Detail,Id=model.Id,Description=model.Description,WorkId=model.WorkId});
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CheckedWork(int id)
        {
            var work = workService.Get(i=>i.Id==id);
            work.Status = true;
            workService.Update(work);

            var adminUserList = await userManager.GetUsersInRoleAsync("Admin"); //Adminleri aldık
            var activeUser = await userManager.FindByNameAsync(User.Identity.Name); //Kullanıcıyı aldık

            foreach (var admin in adminUserList)
            {
                notificationService.Add(new Notification
                {
                    Description = $"{activeUser.Name} {activeUser.Surname} görevini tamamladı",
                    IsRead = false,
                    AppUserId = admin.Id
                });
            }

            return Json(null);
        }
    }
}