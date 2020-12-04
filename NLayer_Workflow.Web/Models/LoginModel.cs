using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NLayer_Workflow.Web.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Boş Geçilemez")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Parola Boş geçilemez")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
