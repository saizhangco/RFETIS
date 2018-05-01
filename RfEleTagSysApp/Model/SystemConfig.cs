using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfEleTagSysApp.Model
{
    public class SystemConfig
    {
        private int id;
        private string key;
        private string value;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }
}
