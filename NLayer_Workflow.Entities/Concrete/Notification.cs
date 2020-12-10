using NLayer_Workflow.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Entities.Concrete
{
    public class Notification:IEntity
    {
        public int Id { get; set; }
        
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public string Description { get; set; }
        public bool IsRead { get; set; }
    }
}
