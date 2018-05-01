using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RfEleTagSysApp.FormModel;
using RfEleTagSysApp.DAL;
using RfEleTagSysApp.DAL.Impl;
using RfEleTagSysApp.Model;

namespace RfEleTagSysApp.BLL.Impl
{
    class UserBLLImpl : UserBLL
    {
        private UserDAL userDAL;

        public UserBLLImpl()
        {
            userDAL = new UserDALImpl();
        }

        public bool create(User user)
        {
            return userDAL.create(user);
        }

        public bool delete(long id)
        {
            return userDAL.delete(id);
        }

        public User findUserById(long id)
        {
            return userDAL.findUserById(id);
        }

        public User findUserByName(string username)
        {
            return userDAL.findUserByName(username);
        }

        public List<User> list()
        {
            return userDAL.list();
        }


        public bool update(User user)
        {
            return userDAL.update(user);
        }
    }
}
