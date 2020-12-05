using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer_Workflow.Bussiness.Abstract;
using NLayer_Workflow.Entities.Concrete;
using NLayer_Workflow.Web.Areas.Admin.Models;

namespace NLayer_Workflow.Web.Areas.Admin.Controllers
{
    public class WorkRulesController : BaseController
    {
        private readonly IAppUserService appUserService;
        private readonly IWorkService workService;
        private readonly UserManager<AppUser> userManager;

        public WorkRulesController(IAppUserService appUserService, IWorkService workService, UserManager<AppUser> userManager)
        {
            this.appUserService = appUserService;
            this.workService = workService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var works = workService.GetAllIncludedTable().Select(i=>new GetWorkAllListModel 
            {
                Id=i.Id,
                AppUser=i.AppUser,
                CreatedDate=i.CreatedDate,
                Description=i.Description,
                Name=i.Name,
                Reports=i.Reports,
                 Urgency=i.Urgency
            }).ToList();

            return View(works);
        }

        public IActionResult WorkDetail(int id)
        {
            var work = workService.GetWorkDetailWithUrgency(id);
            
            var model = new WorkDetail()
            {
                Id=work.Id,
                Description=work.Description,
                CreatedDate=work.CreatedDate,
                Name=work.Name,
                UrgencyDescription=work.Urgency.Description
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult UserToWork(UserToWorkModel model)
        {
            var user=userManager.Users.FirstOrDefault(i => i.Id == model.UserId);
            var work = workService.GetWorkDetailWithUrgency(model.WorkId);

            var userToWorkModel = new UserToWorkListModel();
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
         
            return RedirectToAction("Index");
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
    }
}