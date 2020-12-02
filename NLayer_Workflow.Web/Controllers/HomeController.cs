using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NLayer_Workflow.Bussiness.Abstract;

namespace NLayer_Workflow.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkService _workService;

        public HomeController(IWorkService _workService)
        {
            this._workService = _workService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}