using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NLayer_Workflow.Web.Areas.Member.Controllers
{
    [Authorize(Roles ="Member")]
    [Area("Member")] //Area adını verdik
    public class BaseController : Controller
    {
    }
}