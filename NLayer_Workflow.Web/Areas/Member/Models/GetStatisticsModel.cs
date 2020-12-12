using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayer_Workflow.Web.Areas.Member.Models
{
    public class GetStatisticsModel
    {
        public int ReportCount { get; set; }
        public int WorkCount { get; set; }
        public int NotifyCount { get; set; }
        public int NeedCompleteWorksCount { get; set; }
    }
}
