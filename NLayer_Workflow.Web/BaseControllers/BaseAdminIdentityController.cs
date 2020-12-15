using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer_Workflow.Entities.Concrete;

namespace NLayer_Workflow.Web.BaseControllers
{
    [Authorize(Roles = "Admin")] //Admin olmayan giremez
    [Area("Admin")] //Area olduğunu belirttik
    public class BaseAdminIdentityController : BaseIdentityController
    {
      
        public BaseAdminIdentityController(UserManager<AppUser> userManager):base(userManager)
        {
            
        }

        
    }
}