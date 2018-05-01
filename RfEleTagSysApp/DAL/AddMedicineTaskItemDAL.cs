using RfEleTagSysApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfEleTagSysApp.DAL
{
    interface AddMedicineTaskItemDAL
    {
        bool create(AddMedicineTaskItem item);
        bool delete(int itemId);
        bool update(AddMedicineTaskItem item);
        AddMedicineTaskItem findItemById(int itemId);
        List<AddMedicineTaskItem> list();
        List<AddMedicineTaskItem> findListByTakeId(int taskId);
    }
}
