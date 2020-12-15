using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer_Workflow.Bussiness.Abstract;
using NLayer_Workflow.Entities.Concrete;
using NLayer_Workflow.Entities.DTO.WorkDTO;
using NLayer_Workflow.Web.BaseControllers;

namespace NLayer_Workflow.Web.Areas.Member.Controllers
{
    public class CheckedController : BaseMemberIdentityController
    {
        private readonly IWorkService workService;
        private readonly IMapper mapper;

        public CheckedController(IWorkService workService, UserManager<AppUser> userManager, IMapper mapper):base(userManager)
        {
            this.workService = workService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index(int activePage=1)
        {
            var user = await GetLogInUser();
            int totalPage;
            var works = workService.GetWorksWithPagination(out totalPage,user.Id, activePage);
            var worksModel = mapper.Map<List<WorkIncludedListDto>>(works);
            ViewBag.TotalPage = totalPage;
            ViewBag.ActivePage = activePage;
            return View(worksModel);
        }
    }
}