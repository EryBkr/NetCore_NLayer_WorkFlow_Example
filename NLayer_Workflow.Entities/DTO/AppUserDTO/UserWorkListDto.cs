using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Entities.DTO.AppUserDTO
{
    public class UserWorkListDto
    {
        public AppUser AppUser { get; set; }
        public Work Work { get; set; }
    }
}
