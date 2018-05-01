using RfEleTagSysApp.FormModel;
using RfEleTagSysApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfEleTagSysApp.DAL
{
    interface SystemConfigDAL
    {
        bool create(SystemConfig config);
        bool delete(string k);
        bool update(SystemConfig config);
        SystemConfig get(string key);
        List<SystemConfig> list();
    }
}
