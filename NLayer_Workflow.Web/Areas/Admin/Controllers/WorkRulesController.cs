using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NLayer_Workflow.Web.Areas.Admin.Controllers
{
    public class WorkRulesController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}