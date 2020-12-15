using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer_Workflow.Bussiness.Abstract;
using NLayer_Workflow.Entities.Concrete;
using NLayer_Workflow.Entities.DTO.NotificationDTO;
using NLayer_Workflow.Web.BaseControllers;

namespace NLayer_Workflow.Web.Areas.Admin.Controllers
{
    public class NotificationController : BaseAdminIdentityController
    {
        private readonly INotificationService notificationService;
        private readonly IMapper mapper;

        public NotificationController(INotificationService notificationService, UserManager<AppUser> userManager, IMapper mapper):base(userManager)
        {
            this.notificationService = notificationService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var user = await GetLogInUser();
            var notifies = notificationService.GetList(i => i.AppUserId == user.Id);
            var modelNotifies = mapper.Map<List<NotificationListDto>>(notifies);
            return View(modelNotifies);
        }

        public IActionResult Read(int id)
        {
            var notify = notificationService.Get(i=>i.Id==id);
            notify.IsRead = true;
            notificationService.Update(notify);
            return RedirectToAction("Index");
        }
    }
}