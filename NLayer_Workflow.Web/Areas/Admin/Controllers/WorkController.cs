using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayer_Workflow.Bussiness.Abstract;
using NLayer_Workflow.Entities.Concrete;
using NLayer_Workflow.Web.Areas.Admin.Models;

namespace NLayer_Workflow.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WorkController : Controller
    {
        private readonly IWorkService _workService;
        private readonly IUrgencyService _urgencyService;

        public WorkController(IWorkService _workService, IUrgencyService _urgencyService)
        {
            this._workService = _workService;
            this._urgencyService = _urgencyService;
        }

        public IActionResult Index()
        {
            var works = _workService.GetListWorkWithUrgency().Select(i=>new WorkListModel{Id=i.Id,CreatedDate=i.CreatedDate,Description=i.Description,Name=i.Name,Status=i.Status,Urgency=i.Urgency,UrgencyId=i.UrgencyId }).ToList();

            return View(works);
        }

        public IActionResult AddWork()
        {
            var urgencies=_urgencyService.GetList();
            return View(new WorkAddViewModel {UrgencyList=new SelectList(urgencies,"Id","Description")});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddWork(WorkAddViewModel model)
        {
            _workService.Add(new Work {Name=model.Name,Description=model.Description,UrgencyId=model.UrgencyId });
            return RedirectToAction("Index");
        }
    }
}