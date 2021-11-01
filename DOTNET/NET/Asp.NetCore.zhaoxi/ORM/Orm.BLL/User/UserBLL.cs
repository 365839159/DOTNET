using Orm.DAL.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orm.BLL.User
{
    public class UserBLL
    {
        UserDAL dal = new UserDAL();
        public List<Orm.Model.User> GetUser()
        {
            return dal.GetUsers();
        }
    }
}
