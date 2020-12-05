using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayer_Workflow.Web.Areas.Admin.Models
{
    public class PaginationListUserModel
    {
        public List<AppUser> Users { get; set; } = new List<AppUser>();
        public int PageCount { get; set; }
        public int WorkId { get; set; }
    }
}
