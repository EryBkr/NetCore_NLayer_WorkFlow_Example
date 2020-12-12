using Org.BouncyCastle.Utilities.IO.Pem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayer_Workflow.Web.Areas.Admin.Models
{
    public class GetStatisticsModel
    {
        public int NotAttachWorkCount { get; set; }
        public int CompletedWorksCount { get; set; }
        public int IsNotReadNotifiesCount { get; set; }
        public int TotalReportCount { get; set; }
    }
}
