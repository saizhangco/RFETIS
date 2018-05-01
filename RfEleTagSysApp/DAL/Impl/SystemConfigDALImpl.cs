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
    class SystemConfigDALImpl : SystemConfigDAL
    {
        public bool create(SystemConfig config)
        {
            return SqlHelper.ExecuteNonQuery("insert into systemconfig(K,V) values(@key,@value)",
                new MySqlParameter[] {
                    new MySqlParameter("@key", config.Key),
                    new MySqlParameter("@value", config.Value)
                }) > 0;
        }

        public bool delete(string k)
        {
            return SqlHelper.ExecuteNonQuery("delete from systemconfig where K=@key",
                new MySqlParameter[] {
                    new MySqlParameter("@key", k)
                }) > 0;
        }

        public SystemConfig get(string key)
        {
            SystemConfig config = null;
            DataTable table = SqlHelper.ExecuteDataTable("select * from systemconfig where K=@key",
                new MySqlParameter[] {
                    new MySqlParameter("@key", key)
                });
            if( table.Rows.Count > 0 )
            {
                DataRow row = table.Rows[0];
                config = new SystemConfig();
                config.Id = (int)row[0];
                config.Key = (string)row[1];
                config.Value = (string)row[2];
            }
            return config;
        }

        public List<SystemConfig> list()
        {
            List<SystemConfig> configList = new List<SystemConfig>();
            DataTable table = SqlHelper.ExecuteDataTable("select * from systemconfig");
            foreach (DataRow row in table.Rows)
            {
                SystemConfig config = new SystemConfig();
                config.Id = (int)row[0];
                config.Key = (string)row[1];
                config.Value = (string)row[2];
                configList.Add(config);
            }
            return configList;
        }

        public bool update(SystemConfig config)
        {
            return SqlHelper.ExecuteNonQuery("update systemconfig set V=@value where K=@key",
                new MySqlParameter[] {
                    new MySqlParameter("@value", config.Value),
                    new MySqlParameter("@key", config.Key)
                }) > 0;
        }
    }
}
