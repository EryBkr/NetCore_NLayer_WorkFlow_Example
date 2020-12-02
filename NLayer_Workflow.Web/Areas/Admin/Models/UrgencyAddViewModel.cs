using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NLayer_Workflow.Web.Areas.Admin.Models
{
    public class UrgencyAddViewModel
    {
        [Required(ErrorMessage ="Not Null")]
        [Display(Name ="Tanım")]
        public string Description { get; set; }
    }
}
