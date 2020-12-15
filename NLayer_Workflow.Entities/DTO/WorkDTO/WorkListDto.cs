using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Entities.DTO.WorkDTO
{
    public class WorkListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }

        public int UrgencyId { get; set; }
        public Urgency Urgency { get; set; }
    }
}
