using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Entities.DTO
{
    public class GetUsersCompletedWorkCount
    {
        public string UserName { get; set; }
        public int CompletedWorkCount { get; set; }
    }
}
