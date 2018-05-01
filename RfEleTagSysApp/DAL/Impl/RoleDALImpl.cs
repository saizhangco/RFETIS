using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RfEleTagSysApp.FormModel;
using RfEleTagSysApp.DAL.Impl;
using RfEleTagSysApp.HAL;
using MySql.Data.MySqlClient;
using System.Data;
using RfEleTagSysApp.Model;

namespace RfEleTagSysApp.DAL.Impl
{
    class RoleDALImpl : RoleDAL
    {
        public bool create(Role role)
        {
            return SqlHelper.ExecuteNonQuery("insert into role(Name,Display_en_US,Display_zh_CN,Display_zh_TW) values(@name,@en_US,@zh_CN,@zh_TW)",
                new MySqlParameter[] {
                    new MySqlParameter("@name",  role.Name),
                    new MySqlParameter("@en_US", role.Display_en_US),
                    new MySqlParameter("@zh_CN", role.Display_zh_CN),
                    new MySqlParameter("@zh_TW", role.Display_zh_TW)
                }) > 0;
        }

        public bool delete(long id)
        {
            return SqlHelper.ExecuteNonQuery("delete from role where Id=@id",
                new MySqlParameter[] {
                    new MySqlParameter("@id", id)
                }) > 0;
        }

        public Role get(long id)
        {
            Role role = null;
            DataTable table = SqlHelper.ExecuteDataTable("select * from role where Id=@id",
                new MySqlParameter[] {
                    new MySqlParameter("@id",id)
                });
            if( table.Rows.Count > 0 )
            {
                DataRow row = table.Rows[0];
                role = new Role();
                role.Id = (int)row[0];
                role.Name = (string)row[1];
                role.Display_en_US = (string)row[2];
                role.Display_zh_CN = (string)row[3];
                role.Display_zh_TW = (string)row[4];
            }
            return role;
        }

        public List<Role> list()
        {
            List<Role> roleList = new List<Role>();
            DataTable table = SqlHelper.ExecuteDataTable("select * from role");
            foreach (DataRow row in table.Rows)
            {
                Role role = new Role();
                role.Id = (int)row[0];
                role.Name = (string)row[1];
                role.Display_en_US = (string)row[2];
                role.Display_zh_CN = (string)row[3];
                role.Display_zh_TW = (string)row[4];
                roleList.Add(role);
            }
            return roleList;
        }

        public bool update(Role role)
        {
            return SqlHelper.ExecuteNonQuery("update role set Name=@name,Display_en_US=@en_US,Display_zh_CN=@zh_CN,Display_zh_TW=@zh_TW where Id=@id",
                new MySqlParameter[] {
                    new MySqlParameter("@name",  role.Name),
                    new MySqlParameter("@en_US", role.Display_en_US),
                    new MySqlParameter("@zh_CN", role.Display_zh_CN),
                    new MySqlParameter("@zh_TW", role.Display_zh_TW),
                    new MySqlParameter("@id",    role.Id)
                }) > 0;
        }
    }
}
