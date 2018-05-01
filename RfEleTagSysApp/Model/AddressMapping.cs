using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfEleTagSysApp.Model
{
    public class AddressMapping
    {
        private int id;
        private string addr;
        private int guid;

        public AddressMapping()
        {
            addr = "";
            guid = 0;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Addr
        {
            get { return addr; }
            set { addr = value; }
        }

        public int Guid
        {
            get { return guid; }
            set { guid = value; }
        }
    }
}
