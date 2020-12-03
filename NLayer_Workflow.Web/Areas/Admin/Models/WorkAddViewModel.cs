using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NLayer_Workflow.Web.Areas.Admin.Models
{
    public class WorkAddViewModel
    {
        [Required(ErrorMessage ="Ad Alanı gereklidir")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0,int.MaxValue,ErrorMessage ="Lutfen aciliyet seçiniz")]
        public int UrgencyId { get; set; }

        public SelectList UrgencyList { get; set; }
    }
}
