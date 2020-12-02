using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NLayer_Workflow.Web.Areas.Admin.Models
{
    public class UrgencyUpdateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tanım Alanı Gereklidir")]
        [Display(Name = "Tanım")]
        public string Description { get; set; }
    }
}
