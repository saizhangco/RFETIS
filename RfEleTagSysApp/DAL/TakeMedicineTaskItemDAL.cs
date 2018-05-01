using RfEleTagSysApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfEleTagSysApp.DAL
{
    interface TakeMedicineTaskItemDAL
    {
        bool create(TakeMedicineTaskItem item);
        bool delete(int itemId);
        bool update(TakeMedicineTaskItem item);
        TakeMedicineTaskItem findItemById(int itemId);
        List<TakeMedicineTaskItem> list();
        List<TakeMedicineTaskItem> findListByTakeId(int taskId);
    }
}
