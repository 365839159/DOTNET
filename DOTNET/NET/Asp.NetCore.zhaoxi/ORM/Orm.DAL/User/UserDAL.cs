using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orm.DAL.User
{
    public class UserDAL
    {
        public List<Orm.Model.User> GetUsers()
        {
            using (OrmDbContext context =new OrmDbContext())
            {

                return context.Users.Find().ToList();
            }
        }
    }
}
