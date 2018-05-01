using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfEleTagSysApp.Model
{
    public class AddMedicineTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Items_All { get; set; }
        public int Items_Complete { get; set; }
        public User Manager { get; set; }
        public User Operator { get; set; }
        public string State { get; set; }
    }
}
