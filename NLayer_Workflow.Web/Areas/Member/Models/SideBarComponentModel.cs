using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayer_Workflow.Web.Areas.Member.Models
{
    public class SideBarComponentModel
    {
        public AppUser AppUser { get; set; }
        public int NotifyCount { get; set; }
    }
}
