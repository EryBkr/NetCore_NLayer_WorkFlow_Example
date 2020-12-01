using NLayer_Workflow.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Entities.Concrete
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public List<Work> Works { get; set; } //Work tablosuyla çok ilişki
    }
}
