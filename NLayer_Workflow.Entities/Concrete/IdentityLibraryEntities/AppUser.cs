using Microsoft.AspNetCore.Identity;
using NLayer_Workflow.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Entities.Concrete
{
    public class AppUser:IdentityUser<int>,IEntity //Identity User tablosuna ait entity,Primary Key değerimiz int olacak
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Picture { get; set; } = "defaultProfile.png"; //Default bir resim ataması yaptık

        public List<Work> Works { get; set; } //Work tablosu ile çok ilişki

        public List<Notification> Notifications { get; set; } //Notify tablosu ile bire çok ilişki
    }
}
