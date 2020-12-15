using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayer_Workflow.Bussiness.Abstract;
using NLayer_Workflow.Entities.Concrete;
using NLayer_Workflow.Entities.DTO.WorkDTO;
using NLayer_Workflow.Web.BaseControllers;

namespace NLayer_Workflow.Web.Areas.Admin.Controllers
{
    public class WorkController : BaseAdminController
    {
        private readonly IWorkService _workService;
        private readonly IUrgencyService _urgencyService;
        private readonly IMapper mapper;

        public WorkController(IWorkService _workService, IUrgencyService _urgencyService, IMapper mapper)
        {
            this._workService = _workService;
            this._urgencyService = _urgencyService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var works = _workService.GetListWorkWithUrgency();
            var worksModel = mapper.Map<List<WorkListDto>>(works);

            return View(worksModel);
        }

        [HttpGet]
        public IActionResult AddWork()
        {
            var urgencies=_urgencyService.GetList();
            ViewBag.Urgencies = new SelectList(urgencies, "Id", "Description");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddWork(WorkAddDto model)
        {
            var work = mapper.Map<Work>(model);
            _workService.Add(work);
            return RedirectToAction("Index");
        }

        public IActionResult WorkUpdate(int id)
        {
            var work = _workService.Get(i=>i.Id==id);
            var urgencies = _urgencyService.GetList();
            var workModel = mapper.Map<WorkUpdateDto>(work);
            ViewBag.Urgencies = new SelectList(urgencies, "Id", "Description", workModel.UrgencyId); //Son parametrede seçili olması gerek option'ı verdik

            return View(workModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult WorkUpdate(WorkUpdateDto model)
        {
            var work = mapper.Map<Work>(model);
            _workService.Update(work);
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