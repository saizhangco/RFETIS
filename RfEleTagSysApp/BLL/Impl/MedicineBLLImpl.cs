using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RfEleTagSysApp.FormModel;
using RfEleTagSysApp.DAL;
using RfEleTagSysApp.DAL.Impl;
using RfEleTagSysApp.Model;

namespace RfEleTagSysApp.BLL.Impl
{
    class MedicineBLLImpl : MedicineBLL
    {
        private MedicineDAL medicineDAL;

        public MedicineBLLImpl()
        {
            medicineDAL = new MedicineDALImpl();
        }

        public bool create(Medicine medicine)
        {
            return medicineDAL.create(medicine);
        }

        public bool delete(long id)
        {
            return medicineDAL.delete(id);
        }

        public Medicine findMedicineById(long id)
        {
            return medicineDAL.findMedicineById(id);
        }

        public Medicine findMedicineByName(string name)
        {
            return medicineDAL.findMedicineByName(name);
        }

        public List<Medicine> list()
        {
            return medicineDAL.list();
        }

        public bool update(Medicine medicine)
        {
            return medicineDAL.update(medicine);
        }
    }
}
