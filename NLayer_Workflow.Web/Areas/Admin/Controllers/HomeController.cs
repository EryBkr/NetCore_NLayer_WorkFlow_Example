using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NLayer_Workflow.Bussiness.Abstract;

namespace NLayer_Workflow.Web.Areas.Admin.Controllers
{
    [Area("Admin")] //Area olduğunu belirttik
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
}