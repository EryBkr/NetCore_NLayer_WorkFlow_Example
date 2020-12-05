using NLayer_Workflow.Core.DataAccess.EntityFramework;
using NLayer_Workflow.DataAccess.Abstract;
using NLayer_Workflow.DataAccess.Concrete.EntityFramework.Contexts;
using NLayer_Workflow.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLayer_Workflow.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<MyDataContext, AppUser>, IAppUserDal
    {
        public List<AppUser> GetListWithoutAdmin()
        {
            using (var dB = new MyDataContext()) //Rolü admin olmayan üyeleri aldık
            {
                var adminRoleId = dB.Roles.Where(i => i.Name == "Admin").Select(i=>i.Id).FirstOrDefault();
                var userIDs = dB.UserRoles.Where(i => i.RoleId != adminRoleId).Select(i => i.UserId).ToList();
                var users = new List<AppUser>();
                foreach (var id in userIDs)
                {
                    var user = dB.Users.Find(id);
                    users.Add(user);
                }
                return users;
            }
        }

        public List<AppUser> GetListWithoutAdminInPagination(out int totalPage,string search, int activePage = 1) //Sayfalamaya sahip
        {
            using (var dB = new MyDataContext()) //Rolü admin olmayan üyeleri aldık
            {
                var adminRoleId = dB.Roles.Where(i => i.Name == "Admin").Select(i => i.Id).FirstOrDefault();
                var userIDs = dB.UserRoles.Where(i => i.RoleId != adminRoleId).Select(i => i.UserId).ToList();
                var users = dB.Users.Where(i => userIDs.Contains(i.Id)); //IQueryable şekilde admin olmayan kullanıcıların id lerini sorguladık

                totalPage = (int)Math.Ceiling((double)users.Count() / 3); //toplam sayfa değerini aldık

                if (!string.IsNullOrWhiteSpace(search)) //Search dolu ise
                {
                    users = users.Where(i => i.UserName.ToLower().Contains(search.ToLower()));
                    totalPage = (int)Math.Ceiling((double)users.Count() / 3); //toplam sayfa değerini search sonrası aldık

                } 
                   

                

                 users=users.Skip((activePage - 1) * 3).Take(3); //Pagination
             
                return users.ToList();
            }

        }
    }
}
