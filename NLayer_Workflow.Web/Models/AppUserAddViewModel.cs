using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NLayer_Workflow.Web.Models
{
    public class AppUserAddViewModel
    {
        [Required(ErrorMessage ="Kullanıcı Adı Boş olamaz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Parola Boş olamaz")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage ="Parolalar Eşleşmiyor")]
        public string ConfirmPassword { get; set; }

        [EmailAddress(ErrorMessage = "Geçersiz Email")]
        [Required(ErrorMessage ="Email Alanı boş olamaz")]
        public string Email { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
