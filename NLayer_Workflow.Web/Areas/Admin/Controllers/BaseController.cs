using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NLayer_Workflow.Web.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")] //Admin olmayan giremez
    [Area("Admin")] //Area olduğunu belirttik
    public class BaseController : Controller //Surekli attribute yazmamak için oluşturduk
    {
    }
}