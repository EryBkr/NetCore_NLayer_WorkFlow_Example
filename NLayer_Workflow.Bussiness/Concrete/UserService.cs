using NLayer_Workflow.Bussiness.Abstract;
using NLayer_Workflow.DataAccess.Abstract;
using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NLayer_Workflow.Bussiness.Concrete
{
    public class UserService : IUserService //Service interface lerimizi impelente ettik.Artık İş kodlarımızı bu kısımda yazacağız
    {
        private readonly IUserDal _userDal;

        public UserService(IUserDal _userDal) //DB işlemlerimiz iş katmanında kontrolden geçtikten sonra gerçekleştirilecek.Dependency Injection yöntemi ile Context'e bağlı Interfacel erimizi çağırıyoruz
        {
            this._userDal = _userDal;
        }

        public void Add(User entity)
        {
            _userDal.Add(entity);
        }

        public void Delete(User entity)
        {
            _userDal.Delete(entity);
        }

        public User Get(Expression<Func<User, bool>> filter = null)
        {
            var user=_userDal.Get(filter);
            return user;
        }

        public List<User> GetList(Expression<Func<User, bool>> filter = null)
        {
            var users = _userDal.GetList(filter);
            return users.ToList();
        }

        public void Update(User entity)
        {
            _userDal.Update(entity);
        }
    }
}
