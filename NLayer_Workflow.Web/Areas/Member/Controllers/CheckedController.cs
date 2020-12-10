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
    public class CheckedController : BaseController
    {
        private readonly IWorkService workService;
        private readonly UserManager<AppUser> userManager;

        public CheckedController(IWorkService workService, UserManager<AppUser> userManager)
        {
            this.workService = workService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index(int activePage=1)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            int totalPage;
            var works = workService.GetWorksWithPagination(out totalPage,user.Id, activePage);
            var worksModel = new List<GetWorkListAllModel>();
            ViewBag.TotalPage = totalPage;
            ViewBag.ActivePage = activePage;
            foreach (var item in works)
            {
                worksModel.Add(new GetWorkListAllModel 
                {
                    Id=item.Id,
                    Name=item.Name,
                    AppUser=item.AppUser,
                    CreatedDate=item.CreatedDate,
                    Description=item.Description,
                    Reports=item.Reports,
                    Urgency=item.Urgency
                });
            }
            return View(worksModel);
        }
    }
}