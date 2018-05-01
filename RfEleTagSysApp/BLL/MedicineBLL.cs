using RfEleTagSysApp.FormModel;
using RfEleTagSysApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfEleTagSysApp.BLL
{
    interface MedicineBLL
    {
        //创建药品信息
        bool create(Medicine medicine);
        //删除药品信息
        bool delete(long id);
        //更新药品信息
        bool update(Medicine medicine);
        //通过id获取药品信息
        Medicine findMedicineById(long id);
        //通过name获取药品信息
        Medicine findMedicineByName(string name);
        //获取所有的药品信息
        List<Medicine> list();
    }
}
