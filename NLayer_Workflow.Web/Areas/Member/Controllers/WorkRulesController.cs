using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer_Workflow.Bussiness.Abstract;
using NLayer_Workflow.Entities.Concrete;
using NLayer_Workflow.Entities.DTO.ReportDTO;
using NLayer_Workflow.Entities.DTO.WorkDTO;
using NLayer_Workflow.Web.BaseControllers;

namespace NLayer_Workflow.Web.Areas.Member.Controllers
{
    public class WorkRulesController : BaseMemberIdentityController
    {
        private readonly IWorkService workService;
        private readonly IReportService reportService;
        private readonly INotificationService notificationService;
        private readonly IMapper mapper;

        public WorkRulesController(IWorkService workService, UserManager<AppUser> userManager,IReportService reportService, INotificationService notificationService, IMapper mapper):base(userManager)
        {
            this.workService = workService;
            this.reportService = reportService;
            this.notificationService = notificationService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var user = await GetLogInUser();
            var id = user.Id;
            var works = workService.GetAllIncludedTable(i => i.AppUserId == id && !i.Status);
            var worksModel = mapper.Map<List<WorkIncludedListDto>>(works);
            
            return View(worksModel);
        }

        [HttpGet]
        public IActionResult AddReport(int id)
        {
            var work = workService.Get(i=>i.Id==id);
            var model = mapper.Map<ReportAddDto>(work);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReport(ReportAddDto model)
        {
            var report = mapper.Map<Report>(model);
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
            var model = mapper.Map<ReportUpdatetDto>(report);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateReport(ReportUpdatetDto model)
        {
            var report = mapper.Map<Report>(model);
            reportService.Update(report);
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