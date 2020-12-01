using NLayer_Workflow.Core.Entities.Abstract;
using System;

namespace NLayer_Workflow.Entities.Concrete
{
    public class Work:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }

        public int UserId { get; set; } //Bir İlişki kuruldu
        public User User { get; set; } //Navigation Property
    }
}
