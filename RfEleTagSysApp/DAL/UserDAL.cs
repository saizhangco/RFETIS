using RfEleTagSysApp.FormModel;
using RfEleTagSysApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfEleTagSysApp.DAL
{
    public interface UserDAL
    {
        bool create(User user);
        bool delete(long id);
        bool update(User user);
        User findUserById(long id);
        User findUserByName(string username);
        List<User> list();
    }
}
