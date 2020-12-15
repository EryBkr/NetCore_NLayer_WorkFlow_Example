using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Entities.DTO.WorkDTO
{
    public class WorkDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrgencyDescription { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
