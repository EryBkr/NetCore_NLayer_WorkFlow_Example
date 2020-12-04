using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NLayer_Workflow.Bussiness.Abstract;

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
            var users = appUserService.GetListWithoutAdmin();
            return View();
        }
    }
}