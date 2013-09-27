using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORGRadiusBase
{
    public enum PacketCode : byte
    {
        Access_Request = 1,
        Access_Accespt = 2,
        Access_Reject = 3,
        Accounting_Request = 4,
        Accounting_Response = 5,
        Access_Challenge = 11,
        Status_Server = 12,
        Status_Client = 13,
        Reserved = 255
    };
}
