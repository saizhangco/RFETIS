using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfEleTagSysApp.Controller
{
    public enum EleTagResponseState
    {
        NONE,
        ADDRESS,
        TAKING,
        TAKE_QUERY,
        TAKED,
        ADDING,
        ADD_QUERY,
        ADDED,
        TAKE_ACK_NO_MAPPING,
        ADD_ACK_NO_MAPPING,
        QUERY_ACK_NO_MAPPING,
        TAKING_ERROR,
        TAKED_ERROR,
        ADDING_ERROR,
        ADDED_ERROR
    }

    public delegate void EleTagResponseHandler(int guid, EleTagResponseState state, string msg);
}
