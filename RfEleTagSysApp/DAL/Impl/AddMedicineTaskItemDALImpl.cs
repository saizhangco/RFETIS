using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RfEleTagSysApp.Model;
using RfEleTagSysApp.HAL;
using MySql.Data.MySqlClient;
using System.Data;

namespace RfEleTagSysApp.DAL.Impl
{
    class AddMedicineTaskItemDALImpl : AddMedicineTaskItemDAL
    {
        private TakeMedicineTaskDAL taskDAL = new TakeMedicineTaskDALImpl();
        private MedicineDAL medicineDAL = new MedicineDALImpl();

        public bool create(AddMedicineTaskItem item)
        {
            return SqlHelper.ExecuteNonQuery("insert into AddMedicineTaskItem(Task,Medicine,Amount,State) values(@task,@medicine,@amount,@state)", new
                    MySqlParameter[] {
                     new MySqlParameter("@task",item.Task.Id),
                     new MySqlParameter("@medicine", item.Medicine.Id),
                     new MySqlParameter("@amount", item.Amount),
                     new MySqlParameter("@state", item.State)
                }) > 0;
        }

        public bool delete(int itemId)
        {
            return SqlHelper.ExecuteNonQuery("delete from AddMedicineTaskItem where Id=@id", new
                 MySqlParameter[] {
                     new MySqlParameter("@id",itemId)
                 }) > 0;
        }

        public AddMedicineTaskItem findItemById(int itemId)
        {
            AddMedicineTaskItem item = null;
            DataTable table = SqlHelper.ExecuteDataTable("select * from AddMedicineTaskItem where Id=@id",
                new MySqlParameter[] {
                    new MySqlParameter("@id", itemId)
                });
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                item = new AddMedicineTaskItem();
                item.Id = (int)row[0];
                item.Task = taskDAL.findTaskById((int)row[1]);
                item.Medicine = medicineDAL.findMedicineById((int)row[2]);
                item.Amount = (int)row[3];
                item.State = (int)row[4];
            }
            return item;
        }

        public List<AddMedicineTaskItem> findListByTakeId(int taskId)
        {
            List<AddMedicineTaskItem> itemList = new List<AddMedicineTaskItem>();
            DataTable table = SqlHelper.ExecuteDataTable("select * from AddMedicineTaskItem where Task=@task",
                new MySqlParameter[] {
                    new MySqlParameter("@task", taskId)
                });
            foreach (DataRow row in table.Rows)
            {
                AddMedicineTaskItem item = new AddMedicineTaskItem();
                item.Id = (int)row[0];
                item.Task = taskDAL.findTaskById((int)row[1]);
                item.Medicine = medicineDAL.findMedicineById((int)row[2]);
                item.Amount = (int)row[3];
                item.State = (int)row[4];
                itemList.Add(item);
            }
            return itemList;
        }

        public List<AddMedicineTaskItem> list()
        {
            List<AddMedicineTaskItem> itemList = null;
            DataTable table = SqlHelper.ExecuteDataTable("select * from AddMedicineTaskItem");
            foreach (DataRow row in table.Rows)
            {
                AddMedicineTaskItem item = new AddMedicineTaskItem();
                item.Id = (int)row[0];
                item.Task = taskDAL.findTaskById((int)row[1]);
                item.Medicine = medicineDAL.findMedicineById((int)row[2]);
                item.Amount = (int)row[3];
                item.State = (int)row[4];
                itemList.Add(item);
            }
            return itemList;
        }

        public bool update(AddMedicineTaskItem item)
        {
            return SqlHelper.ExecuteNonQuery("update AddMedicineTaskItem set Task=@task,Medicine=@medicine,Amount=@amount,State=@state where Id=@id", new
                 MySqlParameter[] {
                     new MySqlParameter("@task",item.Task.Id),
                     new MySqlParameter("@medicine", item.Medicine.Id),
                     new MySqlParameter("@amount", item.Amount),
                     new MySqlParameter("@state", item.State),
                     new MySqlParameter("@id", item.Id)
                 }) > 0;
        }
    }
}
