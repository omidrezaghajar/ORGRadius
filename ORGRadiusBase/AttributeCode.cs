using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORGRadiusBase
{
    //public class AttributeCode
    //{
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">شماره</param>
        /// <param name="vendor">برند</param>
        /// <returns>نام attribute</returns>
        //    public string this[int id, vendors vendor, PacketCode pc]
        //    {
        //        get
        //        {
        //            switch (id)
        //            {
        //                case 1:
        //                    if (pc == PacketCode.Access_Request)
        //                        return "Username";
        //                    else if (vendor == vendors.Microsoft)
        //                        return "MS-CHAP-Response";
        //                    else if (vendor == vendors.WISPr)
        //                        return "WISPr-Location-Id";
        //                    else if (vendor == vendors.Mikrotik)
        //                        return "Mikrotik-Recv-Limit";
        //                    break;
        //                case 2:
        //                    if (pc == PacketCode.Access_Request)
        //                        return "User-Password";
        //                    else if (vendor == vendors.WISPr)
        //                        return "WISPr-Location-Name";
        //                    else if (vendor == vendors.Mikrotik)
        //                        return "Mikrotik-Xmit-Limit";
        //                    break;
        //                case 3:
        //                    if (pc == PacketCode.Access_Request)
        //                        return "CHAP-Password";
        //                    else if (vendor == vendors.WISPr)
        //                        return "WISPr-Logoff-URL";
        //                    else if (vendor == vendors.Mikrotik)
        //                        return "Mikrotik-Group";
        //                    break;
        //                case 4:
        //                    if (pc == PacketCode.Access_Request)
        //                        return "NAS-IP-Address";
        //                    else if (vendor == vendors.WISPr)
        //                        return "WISPr-Redirection-URL";
        //                    else if (vendor == vendors.Mikrotik)
        //                        return "Mikrotik-Wireless-Forward";
        //                    break;
        //                case 5:
        //                    if (pc == PacketCode.Access_Request)
        //                        return "NAS-Port";
        //                    else if (vendor == vendors.WISPr)
        //                        return "WISPr-Bandwidth-Min-Up";
        //                    else if (vendor == vendors.Mikrotik)
        //                        return "Mikrotik-Wireless-Skip-Dotlex";
        //                    break;
        //                case 6:
        //                    if (pc == PacketCode.Access_Request)
        //                        return "Service-Type";
        //                    else if (vendor == vendors.WISPr)
        //                        return "WISPr-Bandwidth-Min-Down";
        //                    else if (vendor == vendors.Mikrotik)
        //                        return "Mikrotik-Wireless-Enc-Algo";
        //                    break;
        //                case 7:
        //                    if (pc == PacketCode.Access_Request)
        //                        return "Framed-Protocol";
        //                    else if (vendor == vendors.Microsoft)
        //                        return "MS-MPPE-Encryption-Policy";
        //                    else if (vendor == vendors.WISPr)
        //                        return "WISPr-Bandwidth-Max-Up";
        //                    else if (vendor == vendors.Mikrotik)
        //                        return "Mikrotik-Wireless-Enc-Key";
        //                    break;
        //                case 8:
        //                    if (pc == PacketCode.Access_Request)
        //                        return "Framed-IP-Address";
        //                    if (vendor == vendors.Microsoft)
        //                        return "MS-MPPE-Encryption-Types";
        //                    else if (vendor == vendors.WISPr)
        //                        return "WISPr-Bandwidth-Max-Down";
        //                    else if (vendor == vendors.Mikrotik)
        //                        return "Mikrotik-Rate-Limit";
        //                    else
        //                        return "Framed-IP-Address";
        //                    break;
        //                case 9:
        //                    if (pc == PacketCode.Access_Request && vendor==vendors.Mikrotik)
        //                        return "Mikrotik-Realm";
        //                    else if (vendor == vendors.WISPr)
        //                        return "WISPr-Session-Terminate-Time";
        //                    else
        //                        return "Framed-IP-Netmask";
        //                    break;
        //                case 10:
        //                    if (pc == PacketCode.Access_Request && vendor == vendors.Mikrotik)
        //                        return "Mikrotik-Host-IP";
        //                    else if (vendor == vendors.Microsoft)
        //                        return "MS-CHAP-Domain";
        //                    else
        //                        return "Framed_Routing";
        //                    break;
        //                case 11:
        //                    if (pc == PacketCode.Access_Request && vendor == vendors.Mikrotik)
        //                        return "Mikrotik-Host-IP";
        //                    else if (vendor == vendors.Microsoft)
        //                        return "MS-Domain";
        //                    else
        //                        return "Filter_ID";
        //                    break;
        //                default :
        //                    return "";
        //            }
        //        }
        //    }
        //}
        //public enum vendors
        //{
        //    Standard = 0,
        //    Ascend = 529,
        //    Cisco = 9,
        //    Microsoft = 311,
        //    WISPr = 14122,
        //    Mikrotik = 14988

        //}
        public enum AttributeCode : byte
        {
            User_Name = 1,
            User_Password = 2,
            CHAP_Password = 3,
            NAS_IP_Address = 4,
            NAS_Port = 5,
            Service_Type = 6,
            Framed_protocol = 7,
            Framed_IP_Address = 8,
            Framed_IP_Netmask = 9,
            Framed_Routing = 10,
            Filter_ID = 11,
            Framed_MTU = 12,
            Framed_compression = 13,
            Login_IP_Host = 14,
            Login_Service = 15,
            Login_TCP_Port = 16,
            Reply_Message = 18,
            Callback_Number = 19,
            Callback_Id = 20,
            Framed_Route = 22,
            Framed_IPX_Network = 23,
            State = 24,
            Class = 25,
            Vendor_Specific = 26,
            Session_Timeout = 27,
            Idle_Timeout = 28,
            Termination_action = 29,
            Called_Station_Id = 30,
            Calling_Station_Id = 31,
            Nas_Identifier = 32,
            Proxy_State = 33,
            Login_Lat_service = 34,
            Login_Lat_Node = 35,
            Login_Lat_Group = 36,
            Framed_AppleTalk_Link = 37,
            Framed_AppleTalk_Network = 38,
            Framed_AppleTalk_Zone = 39,

            // Accounting
            Acct_Status_Type = 40,
            Acct_Delay_Time = 41,
            Acct_Input_Octets = 42,
            Acct_Output_Octets = 43,
            Acct_Session_Id = 44,
            Acct_Authentic = 45,
            Acct_Session_Time = 46,
            Acct_Input_Packets = 47,
            Acct_Output_Packets = 48,
            Acct_Terminate_Cause = 49,
            Acct_Multi_Session_Id = 50,
            Acct_Link_Count = 51,

            CHAP_Challenge = 60,
            NAS_Port_Type = 61,
            Port_limit = 62,
            Login_LAT_Port = 63,

            // Tunneling
            Tunnel_Type = 64,
            Tunnel_Medium_Type = 65,
            Tunnel_Client_Endpoint = 66,
            Tunnel_Server_Endpoint = 67,
            Tunnel_Password = 69,
            Tunnel_Private_Group_ID = 81,
            Tunnel_Assignment_ID = 82,
            Tunnel_Preference = 83,
            Tunnel_Client_Auth_ID = 90,
            Tunnel_Server_Auth_ID = 91,

            //Extensions
            Acct_Interim_Interval = 85

        }
    }
