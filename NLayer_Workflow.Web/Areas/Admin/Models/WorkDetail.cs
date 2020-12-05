using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayer_Workflow.Web.Areas.Admin.Models
{
    public class WorkDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrgencyDescription { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
