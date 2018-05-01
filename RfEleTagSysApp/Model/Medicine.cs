using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfEleTagSysApp.Model
{
    public class Medicine
    {
        private int id;
        private string name;
        private AddressMapping address;
        private string description;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public AddressMapping Address
        {
            get { return address; }
            set { address = value; }
        }

        public int MaximumQuantity { set; get; }
        public int ResidualQuantity { set; get; }
    }
}
