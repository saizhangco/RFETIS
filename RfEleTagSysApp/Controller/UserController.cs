using RfEleTagSysApp.BLL;
using RfEleTagSysApp.BLL.Impl;
using RfEleTagSysApp.FormModel;
using RfEleTagSysApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfEleTagSysApp.Controller
{
    class UserController
    {
        private UserBLL userBLL;

        public UserController()
        {
            userBLL = new UserBLLImpl();
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="username">登录用户名</param>
        /// <param name="password">登录密码</param>
        /// <returns>
        /// 0 登录成功
        /// 1 用户名不存在
        /// 2 用户名存在，但密码错误
        /// 3 数据库连接错误
        /// </returns>
        public int login(string username,string password)
        {
            User user = userBLL.findUserByName(username);
            if( user == null )
            {
                return 1;
            }
            if( user.Password != password )
            {
                return 2;
            }
            return 0;
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        /// 0 创建成功
        /// 1 用户名已经存在
        /// 2 数据库连接错误
        /// </returns>
        public int create(User user)
        {
            User origin = userBLL.findUserByName(user.Name);
            if( origin != null )
            {
                return 1;
            }
            origin = user;
            userBLL.create(origin);
            return 0;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        /// 0 删除成功
        /// 1 用户不存在
        /// 2 数据库连接错误
        /// </returns>
        public int delete(User user)
        {
            User origin = userBLL.findUserByName(user.Name);
            if( origin == null )
            {
                return 1;
            }
            userBLL.delete(origin.Id);
            return 0;
        }


        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        /// 0 修改成功
        /// 1 用户不存在
        /// 2 数据库连接错误
        /// </returns>
        public int update(User user)
        {
            User origin = userBLL.findUserById(user.Id);
            if( origin == null )
            {
                return 1;
            }
            origin.Name = user.Name;
            origin.Password = user.Password;
            origin.Role = user.Role;
            userBLL.update(origin);
            return 0;
        }

        /// <summary>
        /// 通过用户名查找用户
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User findUserByName(string username)
        {
            return userBLL.findUserByName(username);
        }

        /// <summary>
        /// 返回用户列表
        /// </summary>
        /// <returns></returns>
        public List<User> list()
        {
            return userBLL.list();
        }
    }
}
