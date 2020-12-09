using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NLayer_Workflow.Web.Areas.Member.Models
{
    public class UpdateReportViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tanım Alanı Boş Geçilemez")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Detay Alanı Boş Geçilemez")]
        public string Detail { get; set; }
        public int WorkId { get; set; }
    }
}
