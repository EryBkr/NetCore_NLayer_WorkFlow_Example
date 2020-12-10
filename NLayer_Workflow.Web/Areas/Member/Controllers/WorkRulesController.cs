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

        public WorkRulesController(IWorkService workService, UserManager<AppUser> userManager,IReportService reportService)
        {
            this.workService = workService;
            this.userManager = userManager;
            this.reportService = reportService;
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
        public IActionResult AddReport(AddReportViewModel model)
        {
            var report = new Report { WorkId = model.WorkId, Detail = model.Detail, Description = model.Description };
            reportService.Add(report);

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

        public IActionResult CheckedWork(int id)
        {
            var work = workService.Get(i=>i.Id==id);
            work.Status = true;
            workService.Update(work);
            return Json(null);
        }
    }
}