using RfEleTagSysApp.DAL;
using RfEleTagSysApp.DAL.Impl;
using RfEleTagSysApp.HAL;
using RfEleTagSysApp.FormModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RfEleTagSysApp.Model;

namespace RfEleTagSysApp.Common.Impl
{
    class SerialComImpl : SerialCom
    {
        private SerialConfigDAL serialConfigDAL;
        private SerialUtil serialUtil;

        public SerialComImpl()
        {
            serialConfigDAL = new SerialConfigDALImpl();
            serialUtil = new SerialUtil();
        }

        /// <summary>
        /// 关闭串口
        /// 1 判断串口是否被打开
        /// 2 关闭串口
        /// </summary>
        public void close()
        {
            if( serialUtil.IsOpen() )
            {
                serialUtil.close();
            }
        }

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <returns></returns>
        public int open()
        {
            if (!serialUtil.IsOpen())
            {
                SerialConfig config = serialConfigDAL.get();
                return serialUtil.open(config.PortName,
                                config.BaudRate,
                                config.DataBits,
                                config.Parity,
                                config.StopBits);
            }
            return 0;
        }

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="portName"></param>
        /// <returns></returns>
        public int open(string portName)
        {
            if (!serialUtil.IsOpen())
            {
                /*
                SerialConfig config = serialConfigDAL.get();
                return serialUtil.open(portName,
                                config.BaudRate,
                                config.DataBits,
                                config.Parity,
                                config.StopBits);
                                */
                return serialUtil.open(portName, 115200, 8, "None", "1");
            }
            return 0;
        }

        /// <summary>
        /// 写数据到串口
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public bool write(byte[] buffer, int offset, int count)
        {
            if (serialUtil.IsOpen())
            {
                serialUtil.write(buffer, offset, count);
            }
            else
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 设置串口数据接收回调函数
        /// </summary>
        /// <param name="handler"></param>
        public void setSerialDataReceivedHandler(SerialDataReceivedHandler handler)
        {
            serialUtil.SerialDataReceived += handler;
        }
    }
}
