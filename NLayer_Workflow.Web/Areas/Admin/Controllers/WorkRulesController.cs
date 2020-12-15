using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer_Workflow.Bussiness.Abstract;
using NLayer_Workflow.Entities.Concrete;
using NLayer_Workflow.Entities.DTO.AppUserDTO;
using NLayer_Workflow.Entities.DTO.WorkDTO;
using NLayer_Workflow.Web.Areas.Admin.Models;
using NLayer_Workflow.Web.BaseControllers;

namespace NLayer_Workflow.Web.Areas.Admin.Controllers
{
    public class WorkRulesController : BaseAdminIdentityController
    {
        private readonly IAppUserService appUserService;
        private readonly IWorkService workService;
        private readonly IFileService fileService;
        private readonly INotificationService notificationService;
        private readonly IMapper mapper;

        public WorkRulesController(IAppUserService appUserService, IWorkService workService, UserManager<AppUser> userManager, IFileService fileService, INotificationService notificationService, IMapper mapper):base(userManager)
        {
            this.appUserService = appUserService;
            this.workService = workService;
            this.fileService = fileService;
            this.notificationService = notificationService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var works = workService.GetAllIncludedTable();
            var worksModel = mapper.Map<List<WorkIncludedListDto>>(works);
            return View(worksModel);
        }

        public IActionResult WorkDetail(int id)
        {
            var work = workService.GetWorkDetailWithUrgency(id);
            var workModel = mapper.Map<WorkDetailDto>(work);
            return View(workModel);
        }

        [HttpGet]
        public IActionResult UserToWork(UserWorkAddDto model)
        {
            var user = userManager.Users.FirstOrDefault(i => i.Id == model.UserId);
            var work = workService.GetWorkDetailWithUrgency(model.WorkId);

            var userToWorkModel = new UserWorkListDto();
            userToWorkModel.AppUser = user;
            userToWorkModel.Work = work;

            return View(userToWorkModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UserToWork(int UserId,int WorkId)
        {
            var work = workService.GetWorkDetailWithUrgency(WorkId);
            work.AppUserId = UserId;
            workService.Update(work);

            notificationService.Add(new Notification 
            {
                AppUserId=UserId,
                Description="Admin tarafından görev atandı",
                IsRead=false
            });
         
            return RedirectToAction("Index");
        }

        public IActionResult WorkDetailWithReport(int id)
        {
            var work = workService.GetWithReportsById(id);
            return View(work);
        }

        public IActionResult Partial_Paginatin_User(string search,int activePage,int WorkId) //Kullanıcı tablosunu partial olarak oluşturduk
        {
            int totalPage;
            var users = appUserService.GetListWithoutAdminInPagination(out totalPage,search,activePage);

            var model = new PaginationListUserModel();
            model.PageCount = totalPage;
            model.Users = users;
            model.WorkId = WorkId;


            return PartialView("Partial_Users", model);
        }

        public FileContentResult CreateExcel(int id)
        {
            var reports = workService.GetWithReportsById(id).Reports;
            return File(fileService.ExecuteExcelf(reports), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Guid.NewGuid()+".xlsx");
        }

        public IActionResult CreatePDF(int id)
        {
            var reports = workService.GetWithReportsById(id).Reports;
            var path = fileService.ExecutePdf(reports);
            return File(path,"application/pdf",Guid.NewGuid()+".pdf");
        }
    }
}