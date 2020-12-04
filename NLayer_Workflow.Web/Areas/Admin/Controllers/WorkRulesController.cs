using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NLayer_Workflow.Bussiness.Abstract;
using NLayer_Workflow.Web.Areas.Admin.Models;

namespace NLayer_Workflow.Web.Areas.Admin.Controllers
{
    public class WorkRulesController : BaseController
    {
        private readonly IAppUserService appUserService;
        private readonly IWorkService workService;

        public WorkRulesController(IAppUserService appUserService, IWorkService workService)
        {
            this.appUserService = appUserService;
            this.workService = workService;
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
    }
}