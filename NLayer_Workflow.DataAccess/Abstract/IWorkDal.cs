using NLayer_Workflow.Core.DataAccess.Abstract;
using NLayer_Workflow.Entities.Concrete;
using System.Collections.Generic;

namespace NLayer_Workflow.DataAccess.Abstract
{
    public interface IWorkDal : IEntityRepository<Work> //Database ile iletişime geçecek soyut yapılarımızı oluşturduk
    {
        List<Work> GetListWorkWithUrgency();
    }
}
