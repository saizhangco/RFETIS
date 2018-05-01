using RfEleTagSysApp.Common;
using RfEleTagSysApp.Common.Impl;
using RfEleTagSysApp.DAL;
using RfEleTagSysApp.DAL.Impl;
using RfEleTagSysApp.FormModel;
using RfEleTagSysApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfEleTagSysApp.Controller
{
    interface EleTagController
    {
        int takeMedicine(int guid, string address, int amount);
        int addMedicine(int guid, string address, int amount);
        int takeMedicine(Medicine medicine, int amount);
        int addMedicine(Medicine medicine, int amount);
        void setEleTagResponseHandler(EleTagResponseHandler handler);
        List<string> getSerialList();
        bool openSerial(string portName);
        bool closeSerial();
    }
}
