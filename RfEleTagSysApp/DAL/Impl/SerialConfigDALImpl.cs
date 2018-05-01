using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RfEleTagSysApp.FormModel;
using RfEleTagSysApp.HAL;
using RfEleTagSysApp.Model;

namespace RfEleTagSysApp.DAL.Impl
{
    class SerialConfigDALImpl : SerialConfigDAL
    {
        public SerialConfig get()
        {
            SerialConfig serial = new SerialConfig();
            SystemConfigDAL systemConfigDAL = new SystemConfigDALImpl();
            SystemConfig portName = systemConfigDAL.get("Serial.portName");
            SystemConfig baudRate = systemConfigDAL.get("Serial.baudRate");
            SystemConfig dataBits = systemConfigDAL.get("Serial.dataBits");
            SystemConfig parity = systemConfigDAL.get("Serial.parity");
            SystemConfig stopBits = systemConfigDAL.get("Serial.stopBits");

            if( portName != null 
                && baudRate != null 
                && dataBits != null 
                && parity != null 
                && stopBits != null )
            {
                //使用数据库默认配置
                serial.PortName = portName.Value;
                serial.BaudRate = int.Parse(baudRate.Value);
                serial.DataBits = int.Parse(dataBits.Value);
                serial.Parity = parity.Value;
                serial.StopBits = stopBits.Value;
            }
            else
            {
                //使用客户端默认配置
                serial.PortName = "COM1";
                serial.BaudRate = 115200;
                serial.DataBits = 8;
                serial.Parity = "None";
                serial.StopBits = "1";
            }
            return serial;
        }

        public bool update(SerialConfig config)
        {
            SystemConfigDAL systemConfigDAL = new SystemConfigDALImpl();
            SystemConfig portName = new SystemConfig() { Key = "Serial.portName", Value = config.PortName };
            SystemConfig baudRate = new SystemConfig() { Key = "Serial.baudRate", Value = config.BaudRate.ToString() };
            SystemConfig dataBits = new SystemConfig() { Key = "Serial.dataBits", Value = config.DataBits.ToString() };
            SystemConfig parity = new SystemConfig() { Key = "Serial.parity", Value = config.Parity };
            SystemConfig stopBits = new SystemConfig() { Key = "Serial.stopBits", Value = config.StopBits };
            if( !systemConfigDAL.update(portName))
            {
                return false;
            }
            if( !systemConfigDAL.update(baudRate))
            {
                return false;
            }
            if( !systemConfigDAL.update(dataBits) )
            {
                return false;
            }
            if( !systemConfigDAL.update(parity))
            {
                return false;
            }
            if( !systemConfigDAL.update(stopBits))
            {
                return false;
            }
            return true;
        }
    }
}
