using RfEleTagSysApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfEleTagSysApp.DAL
{
    public interface TakeMedicineTaskDAL
    {
        bool create(TakeMedicineTask task);
        bool delete(int taskId);
        bool update(TakeMedicineTask task);
        TakeMedicineTask findTaskById(int taskId);
        List<TakeMedicineTask> list();
        List<TakeMedicineTask> findListByOperatorId(int operatorId);
    }
}
