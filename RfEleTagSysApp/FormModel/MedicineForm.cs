using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfEleTagSysApp.FormModel
{
    public class MedicineForm : INotifyPropertyChanged
    {
        private string m_address;
        private string m_request;
        private string m_ack;
        private string m_query;

        public string Name { get; set; }
        public int Amount { get; set; }
        public int Guid { get; set; }
        public string Address
        {
            get { return m_address; }
            set
            {
                m_address = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Address"));
                }
            }
        }

        public string Request
        {
            get { return m_request; }
            set
            {
                m_request = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Request"));
                }
            }
        }

        public string Ack
        {
            get { return m_ack; }
            set
            {
                m_ack = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Ack"));
                }
            }
        }

        public string Query
        {
            get { return m_query; }
            set
            {
                m_query = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Query"));
                }
            }
        }

        public int State { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
