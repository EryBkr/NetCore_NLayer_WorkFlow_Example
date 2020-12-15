using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Entities.DTO.UrgencyDTO
{
   public class UrgencyUpdateDto
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Tanım Alanı Gereklidir")]
        //[Display(Name = "Tanım")]
        public string Description { get; set; }
    }
}
