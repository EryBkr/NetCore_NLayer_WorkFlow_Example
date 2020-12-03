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

        public IActionResult WorkUpdate(int id)
        {
            var work = _workService.Get(i=>i.Id==id);
            var urgencies = _urgencyService.GetList();

            var workModel = new WorkUpdateModel { Id = work.Id, Description = work.Description, Name = work.Name, UrgencyId = work.UrgencyId,UrgencyList= new SelectList(urgencies, "Id", "Description",work.UrgencyId)}; //Son parametrede seçili olması gerek option ı verdik

            return View(workModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult WorkUpdate(WorkUpdateModel model)
        {
            _workService.Update(new Work {Id=model.Id,UrgencyId=model.UrgencyId,Description=model.Description,Name=model.Name});
            return RedirectToAction("Index");
        }

        public JsonResult WorkDelete(int id)
        {
            var work = _workService.Get(i=>i.Id==id);
            _workService.Delete(work);
            return Json(null);
        }
    }
}