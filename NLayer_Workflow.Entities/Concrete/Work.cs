using NLayer_Workflow.Core.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace NLayer_Workflow.Entities.Concrete
{
    public class Work:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        //User ile ilişki
        public int? AppUserId { get; set; } //Nullable tanımlama nedenimiz görev kullanıcıdan önce oluşturulabilir
        public AppUser AppUser { get; set; }

        //Aciliyet İlişkisi
        public int UrgencyId { get; set; }//Nullable tanımlamadık.Bu alan zorunlu tutuldu
        public Urgency Urgency { get; set; }

        public List<Report> Reports { get; set; }
    }
}
