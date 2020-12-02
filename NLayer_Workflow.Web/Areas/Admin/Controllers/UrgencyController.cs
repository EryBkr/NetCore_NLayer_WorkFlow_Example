using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NLayer_Workflow.Bussiness.Abstract;
using NLayer_Workflow.Entities.Concrete;
using NLayer_Workflow.Web.Areas.Admin.Models;

namespace NLayer_Workflow.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UrgencyController : Controller
    {
        private readonly IUrgencyService _urgencyService;

        public UrgencyController(IUrgencyService _urgencyService)
        {
            this._urgencyService = _urgencyService;
        }

        public IActionResult Index()
        {
            var urgencies = _urgencyService.GetList().Select(i=>new UrgencyListViewModel {Id=i.Id,Description=i.Description}).ToList();
            return View(urgencies);
        }

        public IActionResult AddUrgency()
        {
            return View(new UrgencyAddViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUrgency(UrgencyAddViewModel model)
        {
             _urgencyService.Add(new Entities.Concrete.Urgency {Description=model.Description});
            return RedirectToAction("Index");
        }

        public IActionResult UpdateUrgency(int id)
        {
            var urgency = _urgencyService.Get(i=>i.Id==id);
            var model = new UrgencyUpdateViewModel { Id = urgency.Id, Description = urgency.Description };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateUrgency(UrgencyUpdateViewModel model)
        {
            var urgency = new Urgency { Id = model.Id, Description = model.Description };
            _urgencyService.Update(urgency);
            return RedirectToAction("Index");
        }


    }
}