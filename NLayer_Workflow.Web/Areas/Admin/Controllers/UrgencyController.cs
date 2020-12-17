using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer_Workflow.Bussiness.Abstract;
using NLayer_Workflow.Entities.Concrete;
using NLayer_Workflow.Entities.DTO.UrgencyDTO;
using NLayer_Workflow.Web.BaseControllers;

namespace NLayer_Workflow.Web.Areas.Admin.Controllers
{

    public class UrgencyController : BaseAdminController
    {
        private readonly IUrgencyService _urgencyService;
        private readonly IAutoMapperService mapper;

        public UrgencyController(IUrgencyService _urgencyService, IAutoMapperService mapper)
        {
            this._urgencyService = _urgencyService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var urgencies = _urgencyService.GetList();
            var urgenciesModel = mapper.Mapper.Map<List<UrgencyListDto>>(urgencies);
            return View(urgenciesModel);
        }

        public IActionResult AddUrgency()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUrgency(UrgencyAddDto model)
        {
             _urgencyService.Add(new Urgency {Description=model.Description});
            return RedirectToAction("Index");
        }

        public IActionResult UpdateUrgency(int id)
        {
            var urgency = _urgencyService.Get(i=>i.Id==id);
            var model = mapper.Mapper.Map<UrgencyUpdateDto>(urgency);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateUrgency(UrgencyUpdateDto model)
        {
            var urgency = mapper.Mapper.Map<Urgency>(model);
            _urgencyService.Update(urgency);
            return RedirectToAction("Index");
        }


    }
}