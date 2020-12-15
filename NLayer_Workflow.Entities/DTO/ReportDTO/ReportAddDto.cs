using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Entities.DTO.ReportDTO
{
    public class ReportAddDto
    {
        public string Description { get; set; }
        public string Detail { get; set; }
        public int WorkId { get; set; }
        public string WorkName { get; set; }
    }
}
