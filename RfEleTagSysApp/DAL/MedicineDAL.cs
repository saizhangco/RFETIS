using RfEleTagSysApp.FormModel;
using RfEleTagSysApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfEleTagSysApp.DAL
{
    public interface MedicineDAL
    {
        bool create(Medicine medicine);
        bool delete(long id);
        bool update(Medicine medicine);
        Medicine findMedicineById(long id);
        Medicine findMedicineByName(string name);
        List<Medicine> list();
    }
}
