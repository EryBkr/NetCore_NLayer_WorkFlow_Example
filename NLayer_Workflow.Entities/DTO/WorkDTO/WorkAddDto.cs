using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Entities.DTO.WorkDTO
{
    public class WorkAddDto
    {
        //[Required(ErrorMessage = "Ad Alanı gereklidir")]
        public string Name { get; set; }
        public string Description { get; set; }
        //[Range(0, int.MaxValue, ErrorMessage = "Lutfen aciliyet seçiniz")]
        public int UrgencyId { get; set; }
    }
}
