using RfEleTagSysApp.DAL;
using RfEleTagSysApp.DAL.Impl;
using RfEleTagSysApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfEleTagSysApp.Controller
{
    class TakeMedicineTaskController
    {
        private TakeMedicineTaskDAL takeMedicineTaskDAL;

        public TakeMedicineTaskController()
        {
            takeMedicineTaskDAL = new TakeMedicineTaskDALImpl();
        }

        public bool create(TakeMedicineTask task)
        {
            return takeMedicineTaskDAL.create(task);
        }

        public bool delete(int taskId)
        {
            return takeMedicineTaskDAL.delete(taskId);
        }

        public bool update(TakeMedicineTask task)
        {
            return takeMedicineTaskDAL.update(task);
        }

        public TakeMedicineTask findTaskById(int taskId)
        {
            return takeMedicineTaskDAL.findTaskById(taskId);
        }

        public List<TakeMedicineTask> list()
        {
            return takeMedicineTaskDAL.list();
        }

        public List<TakeMedicineTask> findListByOperatorId(int operatorId)
        {
            return takeMedicineTaskDAL.findListByOperatorId(operatorId);
        }
    }
}
