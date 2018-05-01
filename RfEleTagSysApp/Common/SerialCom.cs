using RfEleTagSysApp.HAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfEleTagSysApp.Common
{
    interface SerialCom
    {
        int open();
        int open(string portName);
        bool write(byte[] data, int start, int length);
        void close();
        void setSerialDataReceivedHandler(SerialDataReceivedHandler handler);
    }
}
