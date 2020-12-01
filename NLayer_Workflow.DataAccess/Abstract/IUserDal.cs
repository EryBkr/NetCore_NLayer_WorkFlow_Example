using NLayer_Workflow.Core.DataAccess.Abstract;
using NLayer_Workflow.Entities.Concrete;

namespace NLayer_Workflow.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User> //Database ile iletişime geçecek soyut yapılarımızı oluşturduk ve Generic inteface'i implemente ettik
    {
    }
}
