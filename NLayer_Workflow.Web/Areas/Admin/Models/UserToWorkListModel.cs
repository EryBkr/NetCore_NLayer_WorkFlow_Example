using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayer_Workflow.Web.Areas.Admin.Models
{
    public class UserToWorkListModel
    {
        public AppUser AppUser { get; set; }
        public Work Work { get; set; }
    }
}
