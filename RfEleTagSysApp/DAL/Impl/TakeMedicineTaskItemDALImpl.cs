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
    class TakeMedicineTaskItemDALImpl : TakeMedicineTaskItemDAL
    {
        private TakeMedicineTaskDAL taskDAL = new TakeMedicineTaskDALImpl();
        private MedicineDAL medicineDAL = new MedicineDALImpl();

        public bool create(TakeMedicineTaskItem item)
        {
            return SqlHelper.ExecuteNonQuery("insert into TakeMedicineTaskItem(Task,Medicine,Amount,State) values(@task,@medicine,@amount,@state)",new
                 MySqlParameter[] {
                     new MySqlParameter("@task",item.Task.Id),
                     new MySqlParameter("@medicine", item.Medicine.Id),
                     new MySqlParameter("@amount", item.Amount),
                     new MySqlParameter("@state", item.State)
                 }) > 0;
        }

        public bool delete(int itemId)
        {
            return SqlHelper.ExecuteNonQuery("delete from TakeMedicineTaskItem where Id=@id", new
                 MySqlParameter[] {
                     new MySqlParameter("@id",itemId)
                 }) > 0;
        }

        public TakeMedicineTaskItem findItemById(int itemId)
        {
            TakeMedicineTaskItem item = null;
            DataTable table = SqlHelper.ExecuteDataTable("select * from TakeMedicineTaskItem where Id=@id",
                new MySqlParameter[] {
                    new MySqlParameter("@id", itemId)
                });
            if( table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                item = new TakeMedicineTaskItem();
                item.Id = (int)row[0];
                item.Task = taskDAL.findTaskById((int)row[1]);
                item.Medicine = medicineDAL.findMedicineById((int)row[2]);
                item.Amount = (int)row[3];
                item.State = (int)row[4];
            }
            return item;
        }

        public List<TakeMedicineTaskItem> findListByTakeId(int taskId)
        {
            List<TakeMedicineTaskItem> itemList = new List<TakeMedicineTaskItem>();
            DataTable table = SqlHelper.ExecuteDataTable("select * from TakeMedicineTaskItem where Task=@task",
                new MySqlParameter[] {
                    new MySqlParameter("@task", taskId)
                });
            foreach (DataRow row in table.Rows )
            {
                TakeMedicineTaskItem item = new TakeMedicineTaskItem();
                item.Id = (int)row[0];
                item.Task = taskDAL.findTaskById((int)row[1]);
                item.Medicine = medicineDAL.findMedicineById((int)row[2]);
                item.Amount = (int)row[3];
                item.State = (int)row[4];
                itemList.Add(item);
            }
            return itemList;
        }

        public List<TakeMedicineTaskItem> list()
        {
            List<TakeMedicineTaskItem> itemList = null;
            DataTable table = SqlHelper.ExecuteDataTable("select * from TakeMedicineTaskItem");
            foreach (DataRow row in table.Rows)
            {
                TakeMedicineTaskItem item = new TakeMedicineTaskItem();
                item.Id = (int)row[0];
                item.Task = taskDAL.findTaskById((int)row[1]);
                item.Medicine = medicineDAL.findMedicineById((int)row[2]);
                item.Amount = (int)row[3];
                item.State = (int)row[4];
                itemList.Add(item);
            }
            return itemList;
        }

        public bool update(TakeMedicineTaskItem item)
        {
            return SqlHelper.ExecuteNonQuery("update TakeMedicineTaskItem set Task=@task,Medicine=@medicine,Amount=@amount,State=@state where Id=@id", new
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
