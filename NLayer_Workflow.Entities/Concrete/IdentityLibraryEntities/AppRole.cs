using Microsoft.AspNetCore.Identity;
using NLayer_Workflow.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer_Workflow.Entities.Concrete
{
    public class AppRole:IdentityRole<int>,IEntity //Identity Role tablosuna ait entity, Primary Key değerimiz int olacak
    {
    }
}
