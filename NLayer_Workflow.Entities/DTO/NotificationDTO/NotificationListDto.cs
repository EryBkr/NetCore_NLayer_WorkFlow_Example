using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Entities.DTO.NotificationDTO
{
    public class NotificationListDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
    }
}
