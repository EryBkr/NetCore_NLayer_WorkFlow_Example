using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NLayer_Workflow.Web.Areas.Admin.Models
{
    public class UpdateAdminViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ad Alanı boş olamaz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad Alanı boş olamaz")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Email Alanı boş olamaz")]
        [EmailAddress]
        public string Email { get; set; }
        public string Picture { get; set; }
    }
}
