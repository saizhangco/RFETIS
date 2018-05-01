using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfEleTagSysApp.HAL
{
    /// <summary>  
    ///创建一个SqlHelper的数据库访问通用类，完成对数据库的所有操作  
    /// </summary>  
    class SqlHelper
    {
        //定义数据库的连接字符串  
        private static readonly string connectionString = "server=localhost;port=3306;user=root;password=123456;database=rfet;";

        /// <summary>  
        /// 创建方法，完成对数据库的非查询的操作  
        /// </summary>  
        /// <param name="sql">sql语句</param>  
        /// <param name="parameters">传入的参数</param>  
        /// <returns></returns>  
        public static int ExecuteNonQuery(string sql, params MySqlParameter[] parameters)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parameters);
                    //string str = sql;
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>  
        /// 完成查询的结果值  
        /// </summary>  
        /// <param name="sql">sql语句</param>  
        /// <param name="parameters">传入的参数数组</param>  
        /// <returns></returns>  
        public static int ExecuteScalar(string sql, params MySqlParameter[] parameters)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parameters);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        /// <summary>  
        /// 主要执行查询操作  
        /// </summary>  
        /// <param name="sql">执行的sql语句</param>  
        /// <param name="parameters">参数数组</param>  
        /// <returns></returns>  
        public static DataTable ExecuteDataTable(string sql, params MySqlParameter[] parameters)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parameters);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    return ds.Tables[0];
                }
            }
        }
    }
}
