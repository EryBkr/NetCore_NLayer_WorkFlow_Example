using NLayer_Workflow.Core.DataAccess.EntityFramework;
using NLayer_Workflow.DataAccess.Abstract;
using NLayer_Workflow.DataAccess.Concrete.EntityFramework.Contexts;
using NLayer_Workflow.Entities.Concrete;

namespace NLayer_Workflow.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<MyDataContext, User>, IUserDal //Generic yapımı ve interface'mi implemente ettim
    {
    }
}
