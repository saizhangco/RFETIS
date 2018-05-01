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
    class AddMedicineTaskController
    {
        private AddMedicineTaskDAL addMedicineTaskDAL;

        public AddMedicineTaskController()
        {
            addMedicineTaskDAL = new AddMedicineTaskDALImpl();
        }

        public bool create(AddMedicineTask task)
        {
            return addMedicineTaskDAL.create(task);
        }

        public bool delete(int taskId)
        {
            return addMedicineTaskDAL.delete(taskId);
        }

        public bool update(AddMedicineTask task)
        {
            return addMedicineTaskDAL.update(task);
        }

        public AddMedicineTask findTaskById(int taskId)
        {
            return addMedicineTaskDAL.findTaskById(taskId);
        }

        public List<AddMedicineTask> list()
        {
            return addMedicineTaskDAL.list();
        }

        public List<AddMedicineTask> findListByOperatorId(int operatorId)
        {
            return addMedicineTaskDAL.findListByOperatorId(operatorId);
        }
    }
}
