using RfEleTagSysApp.FormModel;
using RfEleTagSysApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfEleTagSysApp.BLL
{
    interface UserBLL
    {
        //创建用户
        bool create(User user);
        //删除用户
        bool delete(long id);
        //更新用户
        bool update(User user);
        //通过id获取用户信息
        User findUserById(long id);
        //通过name获取用户信息
        User findUserByName(string username);
        //获取所有用户信息
        List<User> list();
    }
}
