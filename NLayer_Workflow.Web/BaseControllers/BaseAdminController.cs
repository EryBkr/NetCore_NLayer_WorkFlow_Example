using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NLayer_Workflow.Web.BaseControllers
{
    [Authorize(Roles = "Admin")] //Admin olmayan giremez
    [Area("Admin")] //Area olduğunu belirttik
    public class BaseAdminController : Controller //Surekli attribute yazmamak için oluşturduk
    {
    }
}