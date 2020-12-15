﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLayer_Workflow.Bussiness.Abstract;
using NLayer_Workflow.Web.Areas.Admin.Models;
using NLayer_Workflow.Web.BaseControllers;

namespace NLayer_Workflow.Web.Areas.Admin.Controllers
{
    public class GraphsController : BaseAdminController
    {
        private readonly IAppUserService appUserService;

        public GraphsController(IAppUserService appUserService)
        {
            this.appUserService = appUserService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult CompletedWorkCount()
        {
            var model = new GraphsModelList();

            model.Works = appUserService.GetUsersWorkCount(true).ToDictionary(i => i.UserName, a => a.CompletedWorkCount);
            var jsonString = JsonConvert.SerializeObject(model.Works);

            return Json(jsonString);
        }

        public JsonResult WorkCount()
        {
            var model = new GraphsModelList();

            model.Works = appUserService.GetUsersWorkCount(false).ToDictionary(i => i.UserName, a => a.CompletedWorkCount);
            var jsonString = JsonConvert.SerializeObject(model.Works);

            return Json(jsonString);
        }
    }
}