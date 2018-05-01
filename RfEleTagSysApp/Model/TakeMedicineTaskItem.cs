using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfEleTagSysApp.Model
{
    public class TakeMedicineTaskItem
    {
        public int Id { get; set; }
        public TakeMedicineTask Task { get; set; }
        public Medicine Medicine { get; set; }
        public int Amount { get; set; }
        public int State { get; set; }
    }
}
