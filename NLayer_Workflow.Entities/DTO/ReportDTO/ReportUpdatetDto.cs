using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Entities.DTO.ReportDTO
{
    public class ReportUpdatetDto
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Tanım Alanı Boş Geçilemez")]
        public string Description { get; set; }
        //[Required(ErrorMessage = "Detay Alanı Boş Geçilemez")]
        public string Detail { get; set; }
        public int WorkId { get; set; }
    }
}
