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
    class AddressMappingDALImpl : AddressMappingDAL
    {
        public bool create(AddressMapping addrmapping)
        {
            return SqlHelper.ExecuteNonQuery("insert into addressmapping(Address,Guid) values(@addr,@guid)",
                new MySqlParameter[] {
                    new MySqlParameter("@addr", addrmapping.Addr),
                    new MySqlParameter("@guid", addrmapping.Guid)
                }) > 0;
        }

        public bool delete(long id)
        {
            return SqlHelper.ExecuteNonQuery("delete from addressmapping where Id=@id", new MySqlParameter[] {
                new MySqlParameter("@id",id)
            }) > 0;
        }

        public AddressMapping findMappingById(long id)
        {
            AddressMapping mapping = null;
            DataTable table = SqlHelper.ExecuteDataTable("select * from addressmapping where Id=@id",
                new MySqlParameter[] {
                    new MySqlParameter("@id", id)
                });
            if( table.Rows.Count > 0 )
            {
                DataRow row = table.Rows[0];
                mapping = new AddressMapping();
                mapping.Id = (int)row[0];
                mapping.Addr = (string)row[1];
                mapping.Guid = (int)row[2];
            }
            return mapping;
        }

        public AddressMapping findMappingByGuid(long medicineId)
        {
            AddressMapping mapping = null;
            DataTable table = SqlHelper.ExecuteDataTable("select * from addressmapping where Guid=@guid",
                new MySqlParameter[] {
                    new MySqlParameter("@guid", medicineId)
                });
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                mapping = new AddressMapping();
                mapping.Id = (int)row[0];
                mapping.Addr = (string)row[1];
                mapping.Guid = (int)row[2];
            }
            return mapping;
        }

        public List<AddressMapping> list()
        {
            List<AddressMapping> mappingList = new List<AddressMapping>();
            DataTable table = SqlHelper.ExecuteDataTable("select * from addressmapping");
            foreach (DataRow row in table.Rows)
            {
                AddressMapping mapping = new AddressMapping();
                mapping.Id = (int)row[0];
                mapping.Addr = (string)row[1];
                mapping.Guid = (int)row[2];
                mappingList.Add(mapping);
            }
            return mappingList;
        }

        public bool update(AddressMapping addrmapping)
        {
            return SqlHelper.ExecuteNonQuery("update addressmapping set Address=@addr,Guid=@guid where Id=@id",
                new MySqlParameter[] {
                    new MySqlParameter("@addr", addrmapping.Addr),
                    new MySqlParameter("@guid", addrmapping.Guid),
                    new MySqlParameter("@id",   addrmapping.Id)
                }) > 0;
        }

        public bool empty()
        {
            SqlHelper.ExecuteNonQuery("delete from addressmapping where 1=1");
            return true;
        }
    }
}
