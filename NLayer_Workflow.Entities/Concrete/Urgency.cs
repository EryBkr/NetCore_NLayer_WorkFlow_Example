using NLayer_Workflow.Core.Entities.Abstract;
using System.Collections.Generic;

namespace NLayer_Workflow.Entities.Concrete
{
    public class Urgency:IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public List<Work> Works { get; set; } //Çok ilişki
    }
}
