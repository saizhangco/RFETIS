using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RfEleTagSysApp.FormModel;
using RfEleTagSysApp.Common;
using RfEleTagSysApp.Common.Impl;
using RfEleTagSysApp.BLL;
using RfEleTagSysApp.DAL;
using RfEleTagSysApp.DAL.Impl;
using System.IO.Ports;
using Microsoft.Win32;
using System.Threading;
using RfEleTagSysApp.Model;

namespace RfEleTagSysApp.Controller.Impl
{
    class RespCache
    {
        public int Guid { get; set; }
        public EleTagResponseState State { get; set; }
    }

    class EleTagControllerImpl : EleTagController
    {

        private SerialCom serialCom;
        private AddressMappingDAL addressMappingDAL;
        private EleTagResponseHandler ResponseHandler;
        private RespCache Cache = new RespCache();

        private enum Status
        {
            SOF, LENGTH, GUID, COMMAND, VALUE
        };
        private Status status = Status.SOF;
        private ResponseMessage responseMsg = new ResponseMessage();
        private int posi = 0;

        public EleTagControllerImpl()
        {
            serialCom = new SerialComImpl();
            addressMappingDAL = new AddressMappingDALImpl();
            serialCom.setSerialDataReceivedHandler(DataReceivedHandler);
        }

        public void setEleTagResponseHandler(EleTagResponseHandler handler)
        {
            ResponseHandler += handler;
        }

        /// <summary>
        /// 补药
        /// </summary>
        /// <param name="medicine"></param>
        /// <param name="amount"></param>
        /// <returns>
        /// 0 成功
        /// 1 药盒的通信地址不存在
        /// 2 
        /// </returns>
        public int addMedicine(Medicine medicine, int amount)
        {
            //1 获取通信地址
            
            AddressMapping mapping = addressMappingDAL.findMappingByGuid(medicine.Address.Guid);
            if (mapping == null)
            {
                return 1;
            }

            RequestMessage requestMessage = new RequestMessage();
            requestMessage.Length = 0;
            requestMessage.Guid = ConvertCom.IntToChar4((int)medicine.Id);
            requestMessage.ShortAddr = ConvertCom.StringToChar4(mapping.Addr);
            // "ADME"
            requestMessage.Command = ConvertCom.StringToChar4("ADME");
            requestMessage.Length = requestMessage.setValue(amount);

            Cache.Guid = 0;
            Cache.State = EleTagResponseState.NONE;
            serialCom.write(requestMessage.getMessageByte(), 0, 14 + requestMessage.Length);
            // 等待成消息返回
            // 最长等待时间10s，循环判断时间间隔10ms
            int count = 1000;
            while (count > 0)
            {
                if (Cache.Guid == (int)medicine.Id && 
                    (Cache.State == EleTagResponseState.TAKING 
                    || Cache.State == EleTagResponseState.TAKING_ERROR ))
                {
                    count = 0;
                }
                Thread.Sleep(10);
                count--;
            }
            return 0;
        }

        public int addMedicine(int guid, string address, int amount)
        {
            return 0;
        }

        /// <summary>
        /// 取药
        /// </summary>
        /// <param name="medicine"></param>
        /// <param name="amount"></param>
        /// <returns>
        /// 0 取药成功
        /// 1 药盒的通信地址不存在
        /// </returns>
        public int takeMedicine(Medicine medicine, int amount)
        {
            //1 获取通信地址
            AddressMapping mapping = addressMappingDAL.findMappingByGuid(medicine.Address.Guid);
            if (mapping == null)
            {
                return 1;
            }

            RequestMessage requestMessage = new RequestMessage();
            requestMessage.Length = 0;
            requestMessage.Guid = ConvertCom.IntToChar4((int)medicine.Id);
            requestMessage.ShortAddr = ConvertCom.StringToChar4(mapping.Addr);
            // TKME
            requestMessage.Command = ConvertCom.StringToChar4("TKME");
            requestMessage.Length = requestMessage.setValue(amount);

            Cache.Guid = 0;
            Cache.State = EleTagResponseState.NONE;
            serialCom.write(requestMessage.getMessageByte(), 0, 14 + requestMessage.Length);
            // 最长等待时间10s，循环判断时间间隔10ms
            int count = 1000;
            while (count > 0)
            {
                if (Cache.Guid == (int)medicine.Id &&
                    (Cache.State == EleTagResponseState.TAKING
                    || Cache.State == EleTagResponseState.TAKING_ERROR))
                {
                    count = 0;
                }
                Thread.Sleep(10);
                count--;
            }
            return 0;
        }

        public int takeMedicine(int guid, string address, int amount)
        {
            RequestMessage requestMessage = new RequestMessage();
            requestMessage.Length = 0;
            requestMessage.Guid = ConvertCom.IntToChar4(guid);
            requestMessage.ShortAddr = ConvertCom.StringToChar4(address);
            // TKME
            requestMessage.Command = ConvertCom.StringToChar4("TKME");
            requestMessage.Length = requestMessage.setValue(amount);

            Cache.Guid = 0;
            Cache.State = EleTagResponseState.NONE;
            serialCom.write(requestMessage.getMessageByte(), 0, 14 + requestMessage.Length);
            // 最长等待时间10s，循环判断时间间隔10ms
            int count = 1000;
            while (count > 0)
            {
                if (Cache.Guid == guid &&
                    (Cache.State == EleTagResponseState.TAKING
                    || Cache.State == EleTagResponseState.TAKING_ERROR))
                {
                    count = 0;
                }
                Thread.Sleep(10);
                count--;
            }
            return 0;
        }

        /// <summary>
        /// 取药确认
        /// </summary>
        /// <param name="guid"></param>
        private void ExecuteTakeAck(int guid)
        {
            //1 获取通信地址
            AddressMapping mapping = addressMappingDAL.findMappingByGuid(guid);
            if (mapping == null)
            {
                return;
            }
            RequestMessage requestMessage = new RequestMessage();
            requestMessage.Length = 2;
            requestMessage.Guid = ConvertCom.IntToChar4(guid);
            requestMessage.ShortAddr = ConvertCom.StringToChar4(mapping.Addr);
            // AKTK
            requestMessage.Command = ConvertCom.StringToChar4("AKTK");
            requestMessage.Value[0] = 'O';
            requestMessage.Value[1] = 'K';

            serialCom.write(requestMessage.getMessageByte(), 0, 14 + requestMessage.Length);
        }

        /// <summary>
        /// 补药确认
        /// </summary>
        /// <param name="guid"></param>
        private void ExecuteAddAck(int guid)
        {
            //1 获取通信地址
            AddressMapping mapping = addressMappingDAL.findMappingByGuid(guid);
            if (mapping == null)
            {
                return;
            }
            RequestMessage requestMessage = new RequestMessage();
            requestMessage.Length = 2;
            requestMessage.Guid = ConvertCom.IntToChar4(guid);
            requestMessage.ShortAddr = ConvertCom.StringToChar4(mapping.Addr);
            // AKAD
            requestMessage.Command = ConvertCom.StringToChar4("AKAD");
            requestMessage.Value[0] = 'O';
            requestMessage.Value[1] = 'K';

            serialCom.write(requestMessage.getMessageByte(), 0, 14 + requestMessage.Length);
        }

        /// <summary>
        /// 查询确认
        /// </summary>
        /// <param name="guid"></param>
        private void ExecuteQueryAck(int guid)
        {
            //1 获取通信地址
            AddressMapping mapping = addressMappingDAL.findMappingByGuid(guid);
            if (mapping == null)
            {
                return;
            }
            RequestMessage requestMessage = new RequestMessage();
            requestMessage.Length = 0;
            requestMessage.Guid = ConvertCom.IntToChar4(guid);
            requestMessage.ShortAddr = ConvertCom.StringToChar4(mapping.Addr);
            // LTME
            requestMessage.Command = ConvertCom.StringToChar4("LTME");
            requestMessage.Length = requestMessage.setValue(12);

            serialCom.write(requestMessage.getMessageByte(), 0, 14 + requestMessage.Length);
        }

        /// <summary>
        /// 串口通信异步回调
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="count"></param>
        private void DataReceivedHandler(byte[] buffer, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (buffer[i] < 32 && buffer[i] != 10 && buffer[i] != 13)
                {
                    //SetRtbRxConsole("[" + (int)data[i] + "]");
                }
                else
                {
                    //SetRtbRxConsole(data[i].ToString());
                }
                switch (status)
                {
                    case Status.SOF:
                        if (buffer[i] == '#')
                        {
                            status = Status.LENGTH;
                        }
                        break;
                    case Status.LENGTH:
                        responseMsg.Length = buffer[i];
                        status = Status.GUID;
                        break;
                    case Status.GUID:
                        responseMsg.Guid[posi++] = (char)buffer[i];
                        if (posi >= 4)
                        {
                            posi = 0;
                            status = Status.COMMAND;
                        }
                        break;
                    case Status.COMMAND:
                        responseMsg.Command[posi++] = (char)buffer[i];
                        if (posi >= 4)
                        {
                            posi = 0;
                            if (responseMsg.Length == 0)
                            {
                                status = Status.SOF;
                                // 处理ResponseMsg
                                ExecuteResponseMsg();
                            }
                            else
                            {
                                status = Status.VALUE;
                            }
                        }
                        break;
                    case Status.VALUE:
                        responseMsg.Value[posi++] = (char)buffer[i];
                        if (posi >= responseMsg.Length || posi >= 33)
                        {
                            responseMsg.Value[posi] = '\0'; //字符串结束，方便后面使用
                            posi = 0;
                            status = Status.SOF;
                            // 处理ResponseMsg
                            ExecuteResponseMsg();
                        }
                        break;
                    default:
                        status = Status.SOF;
                        break;
                }
            }
        }

        /// <summary>
        /// 电子标签返回消息处理
        /// </summary>
        private void ExecuteResponseMsg()
        {
            //SetRtbRxConsole(responseMsg.getMessageByte);
            int id = ConvertCom.Char4ToInt(responseMsg.Guid);
            string command = new string(responseMsg.Command);
            // 1层数据流
            if (command == "PING")
            {
                //在界面上显示心跳
                string _shortAddr = new string(responseMsg.Value, 0, 4);
                //rftaglist[id - Offset - 1].heartBeat(8);
                //SetRtbStatusConsole("" + GenericUtil.Generic_ConvertToGuid(id) + " ----> 网络地址[" + _shortAddr + "]\n");
                //SessionArray[id].ShortAddr = _shortAddr;
                //rftaglist[id - Offset - 1].SetLabelTagID(_shortAddr);
                /*
                 * 1 从数据库中获取guid的mapping信息。
                 * 2 信息存在，判断address是否一致，不一致则更新。
                 * 3 信息不存在，创建一个新的mapping，并保存在数据库。  
                 */
                ResponseHandler(id, EleTagResponseState.ADDRESS, _shortAddr);
                
                AddressMapping mapping = addressMappingDAL.findMappingByGuid(id);
                if( mapping == null )
                {
                    AddressMapping newMapping = new AddressMapping() { Guid = id, Addr = _shortAddr };
                    addressMappingDAL.create(newMapping);
                }
                else
                {
                    if( mapping.Addr != _shortAddr )
                    {
                        mapping.Addr = _shortAddr;
                        addressMappingDAL.update(mapping);
                    }
                }
                
            }
            // 2层数据流
            else if (command == "TKME")
            {
                string respResult = new string(responseMsg.Value, 0, responseMsg.Length);
                if (respResult == "OK")
                {
                    //rftaglist[id - Offset - 1].darkenLED(2);
                    //rftaglist[id - Offset - 1].lightLED(1);
                    //SetRtbStatusConsole("" + GenericUtil.Generic_ConvertToGuid(id) + " ----> 取药命令[成功]\n");
                    ResponseHandler(id, EleTagResponseState.TAKING, "");
                    Cache.Guid = id;
                    Cache.State = EleTagResponseState.TAKING;
                }
                else
                {
                    //rftaglist[id - Offset - 1].darkenLED(1);
                    //rftaglist[id - Offset - 1].darkenLED(2);
                    //string alertValue = "" + GenericUtil.Generic_ConvertToGuid(id) + " ----> 补药命令[错误:" + respResult + "]\n";
                    //SetRtbStatusConsole(alertValue);
                    //MessageBox.Show(alertValue);
                    ResponseHandler(id, EleTagResponseState.TAKING_ERROR, respResult);
                    Cache.Guid = id;
                    Cache.State = EleTagResponseState.TAKING_ERROR;
                }
            }
            // 2层数据流
            else if (command == "ADME")
            {
                string respResult = new string(responseMsg.Value, 0, responseMsg.Length);
                if (respResult == "OK")
                {
                    //rftaglist[id - Offset - 1].darkenLED(1);
                    //rftaglist[id - Offset - 1].lightLED(2);
                    //SetRtbStatusConsole("" + GenericUtil.Generic_ConvertToGuid(id) + " ----> 补药命令[成功]\n");
                    ResponseHandler(id, EleTagResponseState.ADDING, "");
                    Cache.Guid = id;
                    Cache.State = EleTagResponseState.ADDING;
                }
                else
                {
                    //rftaglist[id - Offset - 1].darkenLED(1);
                    //rftaglist[id - Offset - 1].darkenLED(2);
                    //string alertValue = "" + GenericUtil.Generic_ConvertToGuid(id) + " ----> 补药命令[错误:" + respResult + "]\n";
                    //SetRtbStatusConsole(alertValue);
                    //MessageBox.Show(alertValue);
                    ResponseHandler(id, EleTagResponseState.ADDING_ERROR, respResult);
                    Cache.Guid = id;
                    Cache.State = EleTagResponseState.ADDING_ERROR;
                }
            }
            // 3层数据流
            else if (command == "AKTK")
            {
                //1 判断是否为Push Button首次确认
                if (responseMsg.Length == 0)
                {
                    ResponseHandler(id, EleTagResponseState.TAKE_QUERY, "");
                    ExecuteTakeAck(id);
                }
                // 2 
                else
                {
                    string respResult = new string(responseMsg.Value, 0, responseMsg.Length);
                    if (respResult == "OK")
                    {
                        //rftaglist[id - Offset - 1].darkenLED(1);
                        //SetRtbStatusConsole("" + GenericUtil.Generic_ConvertToGuid(id) + " ----> 取药确认[成功]\n");
                        ResponseHandler(id, EleTagResponseState.TAKED, "");
                    }
                    else
                    {
                        //rftaglist[id - Offset - 1].darkenLED(1);
                        //string alertValue = "" + GenericUtil.Generic_ConvertToGuid(id) + " ----> 取药确认[错误:" + respResult + "]\n";
                        //SetRtbStatusConsole(alertValue);
                        //MessageBox.Show(alertValue);
                        ResponseHandler(id, EleTagResponseState.TAKED_ERROR, respResult);
                    }
                }
            }
            // 3层数据流
            else if (command == "AKAD")
            {
                //1 判断是否为Push Button首次确认
                if (responseMsg.Length == 0)
                {
                    ResponseHandler(id, EleTagResponseState.ADD_QUERY, "");
                    ExecuteAddAck(id);
                }
                // 2 
                else
                {
                    string respResult = new string(responseMsg.Value, 0, responseMsg.Length);
                    if (respResult == "OK")
                    {
                        //rftaglist[id - Offset - 1].darkenLED(2);
                        //SetRtbStatusConsole("" + GenericUtil.Generic_ConvertToGuid(id) + " ----> 补药确认[成功]\n");
                        ResponseHandler(id, EleTagResponseState.ADDED, "");
                    }
                    else
                    {
                        //rftaglist[id - Offset - 1].darkenLED(2);
                        //string alertValue = "" + GenericUtil.Generic_ConvertToGuid(id) + " ----> 补药确认[错误:" + respResult + "]\n";
                        //SetRtbStatusConsole(alertValue);
                        //MessageBox.Show(alertValue);
                        ResponseHandler(id, EleTagResponseState.ADDED_ERROR, respResult);
                    }
                }
            }
            // 3层数据流
            else if (command == "LTME")
            {
                //1 判断是否为Push Button首次确认
                if (responseMsg.Length == 0)
                {
                    ResponseHandler(id, EleTagResponseState.NONE, "");
                    ExecuteQueryAck(id);
                }
                // 2 
                else
                {
                    string respResult = new string(responseMsg.Value, 0, responseMsg.Length);
                    if (respResult == "OK")
                    {
                        //SetRtbStatusConsole("" + GenericUtil.Generic_ConvertToGuid(id) + " ----> 查询确认[成功]\n");
                    }
                    else
                    {
                        //string alertValue = "" + GenericUtil.Generic_ConvertToGuid(id) + " ----> 查询确认[错误:" + respResult + "]\n";
                        //SetRtbStatusConsole(alertValue);
                        //MessageBox.Show(alertValue);
                    }
                }
            }
        }

        public List<string> getSerialList()
        {
            List<string> serialList = new List<string>();
            string[] list = SerialPort.GetPortNames();
            //Initial Serial List
            RegistryKey keyCom = Registry.LocalMachine.OpenSubKey("HARDWARE\\DEVICEMAP\\SERIALCOMM");
            if (keyCom != null)
            {
                string[] sSubKeys = keyCom.GetValueNames();
                foreach (string sName in sSubKeys)
                {
                    string sValue = (string)keyCom.GetValue(sName);
                    serialList.Add(sValue);
                }
                return serialList;
            }
            else
            {
                return null;
            }
        }

        public bool openSerial(string portName)
        {
            return serialCom.open(portName) == 0;
        }

        public bool closeSerial()
        {
            serialCom.close();
            return true;
        }
    }
}
