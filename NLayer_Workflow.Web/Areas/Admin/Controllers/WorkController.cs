using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NLayer_Workflow.Bussiness.Abstract;
using NLayer_Workflow.Web.Areas.Admin.Models;

namespace NLayer_Workflow.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WorkController : Controller
    {
        private readonly IWorkService _workService;

        public WorkController(IWorkService _workService)
        {
            this._workService = _workService;
        }

        public IActionResult Index()
        {
            var works = _workService.GetList().Select(i=>new WorkListModel{Id=i.Id,CreatedDate=i.CreatedDate,Description=i.Description,Name=i.Name,Status=i.Status,Urgency=i.Urgency,UrgencyId=i.UrgencyId }).ToList();

            return View(works);
        }
    }
}