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
    class MedicineDALImpl : MedicineDAL
    {
        private AddressMappingDAL mappingDAL;

        public MedicineDALImpl()
        {
            mappingDAL = new AddressMappingDALImpl();
        }


        public bool create(Medicine medicine)
        {
            return SqlHelper.ExecuteNonQuery("insert into medicine(name,guid,description) values(@name, @guid, @desc)",
                new MySqlParameter[] {
                    new MySqlParameter("@name", medicine.Name),
                    new MySqlParameter("@guid", medicine.Address.Guid),
                    new MySqlParameter("@desc", medicine.Description)
                }) > 0;
        }

        public bool delete(long id)
        {
            return SqlHelper.ExecuteNonQuery("delete from medicine where id=@id",
                new MySqlParameter[] {
                    new MySqlParameter("@id", id)
                }) > 0;
        }

        public Medicine findMedicineById(long id)
        {
            Medicine medicine = null;
            DataTable table = SqlHelper.ExecuteDataTable("select * from medicine where id=@id",
                new MySqlParameter[] {
                    new MySqlParameter("@id",id)
                });
            if( table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                medicine = new Medicine();
                medicine.Id = (int)row[0];
                medicine.Name = (string)row[1];
                AddressMapping mapping = mappingDAL.findMappingByGuid((int)row[2]);
                if( mapping == null )
                {
                    mapping = new AddressMapping();
                    mapping.Guid = (int)row[2];
                    mapping.Addr = "";
                }
                medicine.Address = mapping;
                medicine.Description = (string)row[3];
            }
            return medicine;
        }

        public Medicine findMedicineByName(string name)
        {
            Medicine medicine = null;
            DataTable table = SqlHelper.ExecuteDataTable("select * from medicine where name=@name",
                new MySqlParameter[] {
                    new MySqlParameter("@name",name)
                });
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                medicine = new Medicine();
                medicine.Id = (int)row[0];
                medicine.Name = (string)row[1];
                AddressMapping mapping = mappingDAL.findMappingByGuid((int)row[2]);
                if (mapping == null)
                {
                    mapping = new AddressMapping();
                    mapping.Guid = (int)row[2];
                    mapping.Addr = "";
                }
                medicine.Address = mapping;
                medicine.Description = (string)row[3];
            }
            return medicine;
        }

        public List<Medicine> list()
        {
            List<Medicine> medicineList = new List<Medicine>();
            DataTable table = SqlHelper.ExecuteDataTable("select * from medicine");
            foreach (DataRow row in table.Rows)
            {
                Medicine medicine = new Medicine();
                medicine.Id = (int)row[0];
                medicine.Name = (string)row[1];
                AddressMapping mapping = mappingDAL.findMappingByGuid((int)row[2]);
                if (mapping == null)
                {
                    mapping = new AddressMapping();
                    mapping.Guid = (int)row[2];
                    mapping.Addr = "";
                }
                medicine.Address = mapping;
                medicine.Description = (string)row[3];
                medicineList.Add(medicine);
            }
            return medicineList;
        }

        public bool update(Medicine medicine)
        {
            return SqlHelper.ExecuteNonQuery("update medicine set name=@name,guid=@guid,description=@desc where id=@id)",
                new MySqlParameter[] {
                    new MySqlParameter("@name", medicine.Name),
                    new MySqlParameter("@guid", medicine.Address.Guid),
                    new MySqlParameter("@desc", medicine.Description),
                    new MySqlParameter("@id",   medicine.Id)
                }) > 0;
        }
    }
}
