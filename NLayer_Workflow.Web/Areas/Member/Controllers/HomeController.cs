﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NLayer_Workflow.Web.Areas.Member.Controllers
{
    [Area("Member")] //Area adını verdik
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}