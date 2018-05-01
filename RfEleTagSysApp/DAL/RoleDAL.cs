using RfEleTagSysApp.FormModel;
using RfEleTagSysApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfEleTagSysApp.DAL
{
    interface RoleDAL
    {
        bool create(Role role);
        bool delete(long id);
        bool update(Role role);
        Role get(long id);
        List<Role> list();
    }
}
