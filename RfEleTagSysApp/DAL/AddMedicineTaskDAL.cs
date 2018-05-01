using RfEleTagSysApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfEleTagSysApp.DAL
{
    public interface AddMedicineTaskDAL
    {
        bool create(AddMedicineTask task);
        bool delete(int taskId);
        bool update(AddMedicineTask task);
        AddMedicineTask findTaskById(int taskId);
        List<AddMedicineTask> list();
        List<AddMedicineTask> findListByOperatorId(int operatorId);
    }
}
