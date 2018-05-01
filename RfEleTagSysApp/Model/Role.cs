using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfEleTagSysApp.Model
{
    public class Role
    {
        private long id;
        private string name;
        private string display_en_US;
        private string display_zh_CN;
        private string display_zh_TW;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Display_en_US
        {
            get { return display_en_US; }
            set { display_en_US = value; }
        }

        public string Display_zh_CN
        {
            get { return display_zh_CN; }
            set { display_zh_CN = value; }
        }

        public string Display_zh_TW
        {
            get { return display_zh_TW; }
            set { display_zh_TW = value; }
        }

        public override string ToString()
        {
            return "Role [ Id=" + Id +  ", Name=" + Name + ", Display_en_US=" + Display_en_US + ", Display_zh_CN=" + display_zh_CN + ", Display_zh_TW=" + Display_zh_TW + " ]";
        }
    }
}
