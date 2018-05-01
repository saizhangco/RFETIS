using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RfEleTagSysApp.FormModel;
using RfEleTagSysApp.HAL;
using MySql.Data.MySqlClient;
using System.Data;
using RfEleTagSysApp.Model;

namespace RfEleTagSysApp.DAL.Impl
{
    class UserDALImpl : UserDAL
    {
        private RoleDAL roleDAL;

        public UserDALImpl()
        {
            roleDAL = new RoleDALImpl();
        }

        public bool create(User user)
        {
            return SqlHelper.ExecuteNonQuery("insert into user(name,password,role) values(@name,@password,@role)", 
                new MySqlParameter[] 
                {
                    new MySqlParameter("@name",user.Name),
                    new MySqlParameter("@password",user.Password),
                    new MySqlParameter("@role",user.Role)

                }) > 0;
        }

        public bool delete(long id)
        {
            return SqlHelper.ExecuteNonQuery("delete from user where id=@id",
                new MySqlParameter[]
                {
                    new MySqlParameter("@id",id)

                }) > 0;
        }

        public User findUserById(long id)
        {
            User user = null;
            DataTable table = SqlHelper.ExecuteDataTable("select * from user where id=@id",
                new MySqlParameter[] {
                    new MySqlParameter("@id",id)
                });
            if( table.Rows.Count > 0 )
            {
                DataRow row = table.Rows[0];
                user = new User();
                user.Id = (int)row["id"];
                user.Name = (string)row["name"];
                user.Password = (string)row["password"];
                user.Role = roleDAL.get((int)row["role"]);
            }
            return user;
        }

        public User findUserByName(string username)
        {
            User user = null;
            DataTable table = SqlHelper.ExecuteDataTable("select * from user where name=@name",
                new MySqlParameter[] {
                    new MySqlParameter("@name",username)
                });
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                user = new User();
                user.Id = (int)row[0];
                user.Name = (string)row[1];
                user.Password = (string)row[2];
                user.Role = roleDAL.get((int)row[3]);
            }
            return user;
        }

        public List<User> list()
        {
            List<User> userList = new List<User>();
            DataTable table = SqlHelper.ExecuteDataTable("select * from user");
            foreach (DataRow row in table.Rows)
            {
                User user = new User();
                user.Id = (int)row[0];
                user.Name = (string)row[1];
                user.Password = (string)row[2];
                user.Role = roleDAL.get((int)row[3]);
                userList.Add(user);
            }
            return userList;
        }

        public bool update(User user)
        {
            return SqlHelper.ExecuteNonQuery("update user set name=@name, password=@password, role=@role where id=@id",
                new MySqlParameter[] {
                    new MySqlParameter("@name", user.Name),
                    new MySqlParameter("@password", user.Password),
                    new MySqlParameter("@role", user.Role.Id),
                    new MySqlParameter("@id", user.Id)
                }) > 0;
        }
    }
}
