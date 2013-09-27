using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ORGRadiusBase
{

    public sealed class Attributes
    {

        public Attributes()
        {
            Username = null;
            UserPassword = null;
            CHAPPassword = null;
            NASIPAddress = null;
            NASPort = null;
            ServiceType = null;
            FramedProtocol = null;
            FramedIPAddress = null;
            FramedIPNetmask = null;
            FramedRouting = null;
            FilterID = null;
            FramedMTU = null;
            FramedCompression = null;
            LoginIPHost = null;
            LoginService = null;
            LoginTcpPort = null;
            ReplyMessage = null;
            CallbackNumber = null;
            CallbackId = null;
            FramedRoute = null;
            FramedIPXNetwork = null;
            StateObj = null;
            ClassObj = null;
            VendorSpecific = null;
            SessionTimeout = null;
            IdleTimeout = null;
            TerminationAction = null;
            CalledStationId = null;
            CallingStationId = null;
            NasIdentifier = null;
            ProxyState = null;
            LoginLatService = null;
            LoginLatNode = null;
            LoginLatGroup = null;
            FramedAppleTalkLink = null;
            FramedAppleTalkNetwork = null;
            FramedAppleTalkZone = null;
            ChapChallenge = null;
            NasPortType = null;
            PortLimit = null;
            LoginLatGroup = null;
            //Accounting
            AcctStatusType = null;
            AcctDelayTime = null;
            AcctInputOctets = null;
            AcctOutputOctets = null;
            AcctSessionId = null;
            AcctAuthentic = null;
            AcctSessionTime = null;
            AcctInputPackets = null;
            AccOutputPackets = null;
            AcctTerminateCause = null;
            AcctMultiSessionId = null;
            AcctLinkCount = null;
            //Tunneling
            TunnelType = null;
            TunnelMediumType = null;
            TunnelClientEndpoint = null;
            TunnelServerEndpoint = null;
            TunnelPassword = null;
            TunnelPrivateGroupID = null;
            TunnelAssignmentID = null;
            TunnelPreference = null;
            TunnelClientAuthID = null;
            TunnelServerAuthID = null;
        }
        public User_Name Username;
        public User_Password UserPassword;
        public CHAP_Password CHAPPassword;
        public NAS_IP_Address NASIPAddress;
        public NAS_Port NASPort;
        public Service_Type ServiceType;
        public Framed_protocol FramedProtocol;
        public Framed_IP_Address FramedIPAddress;
        public Framed_IP_Netmask FramedIPNetmask;
        public Framed_Routing FramedRouting;
        public Filter_ID FilterID;
        public Framed_MTU FramedMTU;
        public Framed_compression FramedCompression;
        public Login_IP_Host LoginIPHost;
        public Login_Service LoginService;
        public Login_TCP_Port LoginTcpPort;
        public Reply_Message ReplyMessage;
        public Callback_Number CallbackNumber;
        public Callback_Id CallbackId;
        public Framed_Route FramedRoute;
        public Framed_IPX_Network FramedIPXNetwork;
        public State StateObj;
        public Class ClassObj;
        public Vendor_Specific VendorSpecific;
        public Session_Timeout SessionTimeout;
        public Idle_Timeout IdleTimeout;
        public Termination_Action TerminationAction;
        public Called_Station_Id CalledStationId;
        public Calling_Station_Id CallingStationId;
        public Nas_Identifier NasIdentifier;
        public Proxy_State ProxyState;
        public Login_LAT_Service LoginLatService;
        public Login_LAT_Node LoginLatNode;
        public Login_LAT_Group LoginLatGroup;
        public Framed_AppleTalk_Link FramedAppleTalkLink;
        public Framed_AppleTalk_Network FramedAppleTalkNetwork;
        public Framed_AppleTalk_Zone FramedAppleTalkZone;
        public CHAP_Challenge ChapChallenge;
        public NAS_Port_Type NasPortType;
        public Port_limit PortLimit;
        public Login_LAT_Port LogiLatPort;

        //Accounting
        public Acct_Status_Type AcctStatusType;
        public Acct_Delay_Time AcctDelayTime;
        public Acct_Input_Octets AcctInputOctets;
        public Acct_Output_Octets AcctOutputOctets;
        public Acct_Session_Id AcctSessionId;
        public Acct_Authentic AcctAuthentic;
        public Acct_Session_Time AcctSessionTime;
        public Acct_Input_Packets AcctInputPackets;
        public Acct_Output_Packets AccOutputPackets;
        public Acct_Terminate_Cause AcctTerminateCause;
        public Acct_Multi_Session_Id AcctMultiSessionId;
        public Acct_Link_Count AcctLinkCount;

        //Tunneling
        public Tunnel_Type TunnelType;
        public Tunnel_Medium_Type TunnelMediumType;
        public Tunnel_Client_Endpoint TunnelClientEndpoint;
        public Tunnel_Server_Endpoint TunnelServerEndpoint;
        public Tunnel_Password TunnelPassword;
        public Tunnel_Private_Group_ID TunnelPrivateGroupID;
        public Tunnel_Assignment_ID TunnelAssignmentID;
        public Tunnel_Preference TunnelPreference;
        public Tunnel_Client_Auth_ID TunnelClientAuthID;
        public Tunnel_Server_Auth_ID TunnelServerAuthID;
        public Acct_Interim_Interval AcctInterimInterval;
        public class fatherattrib
        {
            protected AttributeCode code;
            protected int valuelength;
            protected byte[] attrvalue;
            public byte[] AttrValue
            {
                get
                {
                    return attrvalue;
                }
            }
        }
        public class User_Name : fatherattrib
        {
            public User_Name(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public User_Name(string username)
            {
                byte[] temp = Encoding.UTF8.GetBytes(username);
                code = AttributeCode.User_Name;
                valuelength = temp.Length;
                attrvalue = new byte[valuelength + 2];
                attrvalue[0] = (byte)AttributeCode.User_Name;
                attrvalue[1] = (byte)(valuelength + 2);
                for (int i = 2, j = 0; j < valuelength; j++, i++)
                {
                    attrvalue[i] = temp[j];
                }
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return Encoding.UTF8.GetString(temp);
                }
            }
        }
        public class User_Password : fatherattrib
        {
            private string _value = "";
            public User_Password(byte[] attrbytes, byte[] ra, string secret)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
                byte[] temp = new byte[valuelength];
                for (int i = 0, j = 2; i < valuelength; i++, j++)
                {
                    temp[i] = attrvalue[j];
                }
                _value = HashPassword(secret, ra, temp);
            }
            private byte[] XOR(byte[] op1, byte[] op2)
            {
                byte[] res = new byte[16];
                for (int i = 0; i < 16; i++)
                {
                    res[i] = (byte)(op1[i] ^ op2[i]);
                }
                return res;
            }
            private string HashPassword(string SecretKey, byte[] RA, byte[] OriginalPassword)
            {
                //kamel shavad
                // byte[] PBytePass = Encoding.UTF8.GetBytes(OriginalPassword);
                string result = "";
                int mylen = OriginalPassword.Length;
                int RowOfBytePass = (int)Math.Ceiling(((double)mylen) / ((double)16.0));
                byte[][] BytePass = new byte[RowOfBytePass][];
                byte[][] ByteC = new byte[RowOfBytePass][];
                byte[][] Byteb = new byte[RowOfBytePass][];
                for (int i = 0; i < RowOfBytePass; i++)
                {
                    BytePass[i] = new byte[16];
                    ByteC[i] = new byte[16];
                    Byteb[i] = new byte[16];
                    for (int j = 0; j < 16; j++)
                    {
                        BytePass[i][j] = 0;
                        ByteC[i][j] = 0;
                        Byteb[i][j] = 0;

                    }
                }

                for (int i = 0; i < mylen; i++)
                    BytePass[i / 16][i % 16] = OriginalPassword[i];
                byte[] SecretByte = Encoding.ASCII.GetBytes(SecretKey);
                for (int i = 0; i < RowOfBytePass; i++)
                {
                    byte[] temp;
                    if (i == 0)
                    {
                        temp = new byte[RA.Length + SecretByte.Length];
                        int j = 0;
                        for (j = 0; j < SecretByte.Length; j++)
                        {
                            temp[j] = SecretByte[j];
                        }
                        for (int k = 0; k < RA.Length; k++, j++)
                        {
                            temp[j] = RA[k];
                        }
                        MD5CryptoServiceProvider m = new MD5CryptoServiceProvider();
                        Byteb[0] = m.ComputeHash(temp); //b1=md5(s+RA)
                        ByteC[0] = XOR(BytePass[0], Byteb[0]);//c0=p0 xor b0
                        string str = Encoding.ASCII.GetString(ByteC[i]);
                        result += str;
                    }
                    else
                    {
                        temp = new byte[SecretByte.Length + ByteC[i - 1].Length];
                        int j = 0;
                        for (j = 0; j < SecretByte.Length; j++)
                        {
                            temp[j] = SecretByte[j];
                        }
                        for (int k = 0; k < ByteC[i - 1].Length; k++, j++)
                        {
                            temp[j] = ByteC[i - 1][k];
                        }
                        MD5CryptoServiceProvider m = new MD5CryptoServiceProvider();
                        Byteb[i] = m.ComputeHash(temp); //bi=md5(s+c(i-1))
                        ByteC[i] = XOR(BytePass[i], Byteb[i]);//ci=pi xor bi
                        string str = Encoding.ASCII.GetString(ByteC[i]);
                        //MessageBox.Show(str);
                        result += str;
                    }
                }

                //string res = Encoding.UTF8.GetString(c1);

                //  MessageBox.Show(result);
                int nullrecognition = 0;
                for (; ; nullrecognition++)
                {
                    if (result[nullrecognition] == '\0')
                        break;
                }
                result = result.Remove(nullrecognition);
                return result;
            }
            public string value
            {
                get
                {
                    return _value;
                }
            }
        }
        public class CHAP_Password : fatherattrib
        {
            int _chapident;
            public CHAP_Password(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                _chapident = attrbytes[2];
                valuelength = Convert.ToInt32(attrbytes[1]) - 3;
            }
            public int ChapIdent
            {
                get
                {
                    return _chapident;
                }
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength - 1];
                    for (int i = 0, j = 3; i < valuelength - 1; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return Encoding.UTF8.GetString(temp);
                }
            }
        }
        public class NAS_IP_Address : fatherattrib
        {
            public NAS_IP_Address(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return temp[0].ToString() + "." + temp[1].ToString() + "." + temp[2].ToString() + "." + temp[3].ToString();
                }
            }
        }
        public class NAS_Port : fatherattrib
        {
            public NAS_Port(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public uint value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    return val;
                }
            }
        }
        public class Service_Type : fatherattrib
        {
            public Service_Type(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public Service_Type(Enu_Service_Type t)
            {
                valuelength = 4;
                attrvalue = new byte[6];
                attrvalue[0] = (byte)AttributeCode.Service_Type;
                attrvalue[1] = 6;
                uint val=(uint)t;
                attrvalue[5] = (byte)val;
                val = val >> 8;
                attrvalue[4] = (byte)val;
                val = val >> 8;
                attrvalue[3] = (byte)val;
                val = val >> 8;
                attrvalue[2] = (byte)val;

            }
            public Enu_Service_Type value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    Enu_Service_Type t = (Enu_Service_Type)val;
                    return t;
                }
            }
            public enum Enu_Service_Type : uint
            {
                Login = 1,
                Framed = 2,
                Callback_Login = 3,
                Callback_Framed = 4,
                Outbound = 5,
                Administrative = 6,
                NAS_Prompt = 7,
                Authenticate_Only = 8,
                Callback_NAS_Prompt = 9,
                Call_Check = 10,
                Callback_Administrative = 11
            }
        }
        public class Framed_protocol : fatherattrib
        {
            public Framed_protocol(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public Framed_protocol(Enu_Framed_protocol t)
            {
                attrvalue = new byte[6];
                valuelength = 4;
                attrvalue[0] = (byte)AttributeCode.Framed_protocol;
                attrvalue[1] = 6;
                uint val = (uint)t;
                attrvalue[5] = (byte)val;
                val = val >> 8;
                attrvalue[4] = (byte)val;
                val = val >> 8;
                attrvalue[3] = (byte)val;
                val = val >> 8;
                attrvalue[2] = (byte)val;
            }
            public Enu_Framed_protocol value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    Enu_Framed_protocol t = (Enu_Framed_protocol)val;
                    return t;
                }
            }
            public enum Enu_Framed_protocol : uint
            {
                PPP = 1,
                SLIP = 2,
                ARAP = 3,
                Gandalf_proprietary_SingleLink_MultiLink_protocol = 4,
                Xylogics_proprietary_IPX_SLIP = 5,
                X_75_Synchronous = 6
            }
        }
        public class Framed_IP_Address : fatherattrib
        {
            public Framed_IP_Address(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public Framed_IP_Address(string ip)
            {
                attrvalue = new byte[6];
                valuelength = 4;
                attrvalue[0] = (byte)AttributeCode.Framed_IP_Address;
                attrvalue[1] = 6;
                string[] str = ip.Split('.');
                attrvalue[2] = byte.Parse(str[0]);
                attrvalue[3] = byte.Parse(str[1]);
                attrvalue[4] = byte.Parse(str[2]);
                attrvalue[5] = byte.Parse(str[3]);
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return temp[0].ToString() + "." + temp[1].ToString() + "." + temp[2].ToString() + "." + temp[3].ToString();
                }
            }
        }
        public class Framed_IP_Netmask : fatherattrib
        {
            public Framed_IP_Netmask(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public Framed_IP_Netmask(string ip)
            {
                attrvalue = new byte[6];
                valuelength = 4;
                attrvalue[0] = (byte)AttributeCode.Framed_IP_Netmask;
                attrvalue[1] = 6;
                string[] str = ip.Split('.');
                attrvalue[2] = byte.Parse(str[0]);
                attrvalue[3] = byte.Parse(str[1]);
                attrvalue[4] = byte.Parse(str[2]);
                attrvalue[5] = byte.Parse(str[3]);
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return temp[0].ToString() + "." + temp[1].ToString() + "." + temp[2].ToString() + "." + temp[3].ToString();
                }
            }
        }
        public class Framed_Routing : fatherattrib
        {
            public Framed_Routing(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public Enu_Framed_Routing value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    Enu_Framed_Routing t = (Enu_Framed_Routing)val;
                    return t;
                }
            }
            public enum Enu_Framed_Routing : uint
            {
                None = 0,
                Send_routing_packets = 1,
                Listen_for_routing_packets = 2,
                Send_and_Listen = 3
            }
        }
        public class Filter_ID : fatherattrib
        {
            public Filter_ID(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return Encoding.UTF8.GetString(temp);
                }
            }
        }
        public class Framed_MTU : fatherattrib
        {
            public Framed_MTU(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public Framed_MTU(uint val)
            {
                attrvalue = new byte[6];
                attrvalue[0] = (byte)AttributeCode.Framed_MTU;
                attrvalue[1] = 6;
                attrvalue[5] = (byte)val;
                val = val >> 8;
                attrvalue[4] = (byte)val;
                val = val >> 8;
                attrvalue[3] = (byte)val;
                val = val >> 8;
                attrvalue[2] = (byte)val;
            }
            public long value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    return val;
                }
            }
        }
        public class Framed_compression : fatherattrib
        {
            public Framed_compression(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public Framed_compression(Enu_Framed_compression t)
            {
                attrvalue = new byte[6];
                attrvalue[0] = (byte)AttributeCode.Framed_compression;
                attrvalue[1] = 6;
                uint val = (uint)t;
                attrvalue[5] = (byte)val;
                val = val >> 8;
                attrvalue[4] = (byte)val;
                val = val >> 8;
                attrvalue[3] = (byte)val;
                val = val >> 8;
                attrvalue[2] = (byte)val;
            }
            public Enu_Framed_compression value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    Enu_Framed_compression t = (Enu_Framed_compression)val;
                    return t;
                }
            }
            public enum Enu_Framed_compression : uint
            {
                None = 0,
                VJ_TCP_IP_header_compression = 1,
                IPX_header_compression = 2,
                Stac_LZS_compression = 3
            }
        }
        public class Login_IP_Host : fatherattrib
        {
            public Login_IP_Host(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return temp[0].ToString() + "." + temp[1].ToString() + "." + temp[2].ToString() + "." + temp[3].ToString();
                }
            }
        }
        public class Login_Service : fatherattrib
        {
            public Login_Service(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public Enu_Login_Service value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    Enu_Login_Service t = (Enu_Login_Service)val;
                    return t;
                }
            }
            public enum Enu_Login_Service : long
            {
                Telnet = 0,
                Rlogin = 1,
                TCP_Clear = 2,
                PortMaster = 3,
                LAT = 4,
                X25_PAD = 5,
                X25_T3POS = 6,
                TCP_Clear_Quiet = 8
            }
        }
        public class Login_TCP_Port : fatherattrib
        {
            public Login_TCP_Port(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public uint value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    return val;
                }
            }
        }
        public class Reply_Message : fatherattrib
        {
            public Reply_Message(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public Reply_Message(string val)
            {
                byte[] v = Encoding.UTF8.GetBytes(val);
                attrvalue = new byte[v.Length + 2];
                attrvalue[0] = (byte)AttributeCode.Reply_Message;
                attrvalue[1] = (byte)attrvalue.Length;
                valuelength = attrvalue[1] - 2;
                for (int i = 2, j=0; i < attrvalue.Length; i++,j++)
                {
                    attrvalue[i] = v[j];
                }
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return Encoding.UTF8.GetString(temp);
                }
            }
        }
        public class Callback_Number : fatherattrib
        {
            public Callback_Number(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return Encoding.UTF8.GetString(temp);
                }
            }
        }
        public class Callback_Id : fatherattrib
        {
            public Callback_Id(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return Encoding.UTF8.GetString(temp);
                }
            }
        }
        public class Framed_Route : fatherattrib
        {
            public Framed_Route(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public Framed_Route(string val)
            {
                byte[] v = Encoding.UTF8.GetBytes(val);
                attrvalue = new byte[v.Length + 2];
                attrvalue[0] = (byte)AttributeCode.Reply_Message;
                attrvalue[1] = (byte)attrvalue.Length;
                for (int i = 2, j = 0; i < attrvalue.Length; i++, j++)
                {
                    attrvalue[i] = v[j];
                }
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return Encoding.UTF8.GetString(temp);
                }
            }
        }
        public class Framed_IPX_Network : fatherattrib
        {
            public Framed_IPX_Network(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return temp[0].ToString() + "." + temp[1].ToString() + "." + temp[2].ToString() + "." + temp[3].ToString();
                }
            }
        }
        public class State : fatherattrib
        {
            public State(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public State(string val)
            {
                byte[] v = Encoding.UTF8.GetBytes(val);
                attrvalue = new byte[v.Length + 2];
                attrvalue[0] = (byte)AttributeCode.State;
                attrvalue[1] = (byte)attrvalue.Length;
                for (int i = 2, j = 0; i < attrvalue.Length; i++, j++)
                {
                    attrvalue[i] = v[j];
                }
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return Encoding.UTF8.GetString(temp);
                }
            }
        }
        public class Class : fatherattrib
        {
            public Class(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public Class(string val)
            {
                byte[] v = Encoding.UTF8.GetBytes(val);
                attrvalue = new byte[v.Length + 2];
                attrvalue[0] = (byte)AttributeCode.Class;
                attrvalue[1] = (byte)attrvalue.Length;
                for (int i = 2, j = 0; i < attrvalue.Length; i++, j++)
                {
                    attrvalue[i] = v[j];
                }
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return Encoding.UTF8.GetString(temp);
                }
            }
        }
        public class Vendor_Specific : fatherattrib
        {
            public Vendor_Specific(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public uint Vendor_ID
            {
                get
                {
                    byte[] temp = new byte[4];
                    for (int i = 0, j = 2; i < 4; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    return val;
                }
            }
            public string Vendor_Specific_String
            {
                get
                {
                    byte[] temp = new byte[valuelength - 4];
                    for (int i = 0, j = 6; i < valuelength - 4; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }

                    return Encoding.UTF8.GetString(temp);
                }
            }
        }
        public class Session_Timeout : fatherattrib
        {
            public Session_Timeout(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public Session_Timeout(uint val)
            {
                attrvalue = new byte[6];
                attrvalue[0] = (byte)AttributeCode.Session_Timeout;
                attrvalue[1] = 6;
                attrvalue[5] = (byte)val;
                val = val >> 8;
                attrvalue[4] = (byte)val;
                val = val >> 8;
                attrvalue[3] = (byte)val;
                val = val >> 8;
                attrvalue[2] = (byte)val;
            }
            public uint value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    return val;
                }
            }
        }
        public class Idle_Timeout : fatherattrib
        {
            public Idle_Timeout(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public Idle_Timeout(uint val)
            {
                attrvalue = new byte[6];
                attrvalue[0] = (byte)AttributeCode.Idle_Timeout;
                attrvalue[1] = 6;
                attrvalue[5] = (byte)val;
                val = val >> 8;
                attrvalue[4] = (byte)val;
                val = val >> 8;
                attrvalue[3] = (byte)val;
                val = val >> 8;
                attrvalue[2] = (byte)val;
            }
            public uint value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    return val;
                }
            }
        }
        public class Termination_Action : fatherattrib
        {
            public Termination_Action(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public Termination_Action(Enu_Termination_Action t)
            {
                attrvalue = new byte[6];
                attrvalue[0] = (byte)AttributeCode.Termination_action;
                uint val = (uint)t;
                attrvalue[1] = 6;
                attrvalue[5] = (byte)val;
                val = val >> 8;
                attrvalue[4] = (byte)val;
                val = val >> 8;
                attrvalue[3] = (byte)val;
                val = val >> 8;
                attrvalue[2] = (byte)val;
            }
            public Enu_Termination_Action value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    Enu_Termination_Action t = (Enu_Termination_Action)val;
                    return t;
                }
            }
            public enum Enu_Termination_Action : uint
            {
                Default = 0,
                RADIUS_Request = 1
            }
        }
        public class Called_Station_Id : fatherattrib
        {
            public Called_Station_Id(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return Encoding.UTF8.GetString(temp);
                }
            }
        }
        public class Calling_Station_Id : fatherattrib
        {
            public Calling_Station_Id(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return Encoding.UTF8.GetString(temp);
                }
            }
        }
        public class Nas_Identifier : fatherattrib
        {
            public Nas_Identifier(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return Encoding.UTF8.GetString(temp);
                }
            }
        }
        public class Proxy_State : fatherattrib
        {
            public Proxy_State(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return Encoding.UTF8.GetString(temp);
                }
            }
        }
        public class Login_LAT_Service : fatherattrib
        {
            public Login_LAT_Service(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return Encoding.UTF8.GetString(temp);
                }
            }
        }
        public class Login_LAT_Node : fatherattrib
        {
            public Login_LAT_Node(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return Encoding.UTF8.GetString(temp);
                }
            }
        }
        public class Login_LAT_Group : fatherattrib
        {
            public Login_LAT_Group(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return Encoding.UTF8.GetString(temp);
                }
            }
        }
        public class Framed_AppleTalk_Link : fatherattrib
        {
            public Framed_AppleTalk_Link(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public uint value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    return val;
                }
            }
        }
        public class Framed_AppleTalk_Network : fatherattrib
        {
            public Framed_AppleTalk_Network(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public uint value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    return val;
                }
            }
        }
        public class Framed_AppleTalk_Zone : fatherattrib
        {
            public Framed_AppleTalk_Zone(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return Encoding.UTF8.GetString(temp);
                }
            }
        }
        public class CHAP_Challenge : fatherattrib
        {
            public CHAP_Challenge(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return Encoding.UTF8.GetString(temp);
                }
            }
        }
        public class NAS_Port_Type : fatherattrib
        {
            public NAS_Port_Type(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public Enu_NAS_Port_Type value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    Enu_NAS_Port_Type t = (Enu_NAS_Port_Type)val;
                    return t;
                }
            }
            public enum Enu_NAS_Port_Type : uint
            {
                Async = 0,
                Sync = 1,
                ISDN_Sync = 2,
                ISDN_Async_V_120 = 3,
                ISDN_Async_V_110 = 4,
                Virtual = 5,
                PIAFS = 6,
                HDLC_Clear_Channel = 7,
                X_25 = 8,
                X_75 = 9,
                G_3_Fax = 10,
                SDSL = 11,
                ADSL_CAP = 12,
                ADSL_DMT = 13,
                IDSL = 14,
                Ethernet = 15,
                xDSL = 16,
                Cable = 17,
                Wireless_Other = 18,
                Wireless_IEEE_802_11 = 19
            }

        }
        public class Port_limit : fatherattrib
        {
            public Port_limit(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public Port_limit(uint val)
            {
                attrvalue = new byte[6];
                attrvalue[0] = (byte)AttributeCode.Port_limit;
                attrvalue[1] = 6;
                attrvalue[5] = (byte)val;
                val = val >> 8;
                attrvalue[4] = (byte)val;
                val = val >> 8;
                attrvalue[3] = (byte)val;
                val = val >> 8;
                attrvalue[2] = (byte)val;
            }
            public uint value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    return val;
                }
            }
        }
        public class Login_LAT_Port : fatherattrib
        {
            public Login_LAT_Port(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return Encoding.UTF8.GetString(temp);
                }
            }
        }

        /// <summary>
        /// Accounting Attributes
        /// </summary>
        public class Acct_Status_Type : fatherattrib
        {
            public Acct_Status_Type(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public Enu_Acct_Status_Type value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    Enu_Acct_Status_Type t = (Enu_Acct_Status_Type)val;
                    return t;
                }
            }
            public enum Enu_Acct_Status_Type : uint
            {
                Start = 1,
                Stop = 2,
                Interim_Update = 3,
                Accounting_On = 7,
                Accounting_Off = 8,
                Reserved_for_Tunnel_Accounting = 9,
                Reserved_for_Failed = 15
            }
        }
        public class Acct_Delay_Time : fatherattrib
        {
            public Acct_Delay_Time(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public uint value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    return val;
                }
            }
        }
        public class Acct_Input_Octets : fatherattrib
        {
            public Acct_Input_Octets(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public uint value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    return val;
                }
            }
        }
        public class Acct_Output_Octets : fatherattrib
        {
            public Acct_Output_Octets(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public uint value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    return val;
                }
            }
        }
        public class Acct_Session_Id : fatherattrib
        {
            public Acct_Session_Id(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return Encoding.UTF8.GetString(temp);
                }
            }
        }
        public class Acct_Authentic : fatherattrib
        {
            public Acct_Authentic(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public Enu_Acct_Authentic value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    Enu_Acct_Authentic t = (Enu_Acct_Authentic)val;
                    return t;
                }
            }
            public enum Enu_Acct_Authentic : uint
            {
                RADIUS = 1,
                Local = 2,
                Remote = 3
            }
        }
        public class Acct_Session_Time : fatherattrib
        {
            public Acct_Session_Time(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public uint value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    return val;
                }
            }
        }
        public class Acct_Input_Packets : fatherattrib
        {
            public Acct_Input_Packets(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public uint value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    return val;
                }
            }
        }
        public class Acct_Output_Packets : fatherattrib
        {
            public Acct_Output_Packets(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public uint value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    return val;
                }
            }
        }
        public class Acct_Terminate_Cause : fatherattrib
        {
            public Acct_Terminate_Cause(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public Enu_Acct_Terminate_Cause value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    Enu_Acct_Terminate_Cause t = (Enu_Acct_Terminate_Cause)val;
                    return t;
                }
            }
            public enum Enu_Acct_Terminate_Cause : uint
            {
                User_Request = 1,
                Lost_Carrier = 2,
                Lost_Service = 3,
                Idle_Timeout = 4,
                Session_Timeout = 5,
                Admin_Reset = 6,
                Admin_Reboot = 7,
                Port_Error = 8,
                NAS_Error = 9,
                NAS_Request = 10,
                NAS_Reboot = 11,
                Port_Unneeded = 12,
                Port_Preempted = 13,
                Port_Suspended = 14,
                Service_Unavailable = 15,
                Callback = 16,
                User_Error = 17,
                Host_Request = 18
            }
        }
        public class Acct_Multi_Session_Id : fatherattrib
        {
            public Acct_Multi_Session_Id(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return Encoding.UTF8.GetString(temp);
                }
            }
        }
        public class Acct_Link_Count : fatherattrib
        {
            public Acct_Link_Count(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public uint value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    return val;
                }
            }
        }
        public class Tunnel_Type : fatherattrib
        {
            int _Tag;
            public Tunnel_Type(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                _Tag = attrbytes[2];
                valuelength = Convert.ToInt32(attrbytes[1]) - 3;
            }
            public int Tag
            {
                get
                {
                    return _Tag;
                }
            }
            public Enu_Tunnel_Type value
            {
                get
                {
                    byte[] temp = new byte[valuelength - 1];
                    for (int i = 0, j = 3; i < valuelength - 1; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    Enu_Tunnel_Type t = (Enu_Tunnel_Type)val;
                    return t;
                }
            }
            public enum Enu_Tunnel_Type : uint
            {
                PPTP = 1,
                L2F = 2,
                L2TP = 3,
                ATMP = 4,
                VTP = 5,
                AH = 6,
                IP_IP = 7,
                MIN_IP_IP = 8,
                ESP = 9,
                GRE = 10,
                DVS = 11,
                IP_in_IP_Tunneling = 12
            }
        }
        public class Tunnel_Medium_Type : fatherattrib
        {
            int _Tag;
            public Tunnel_Medium_Type(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                _Tag = attrbytes[2];
                valuelength = Convert.ToInt32(attrbytes[1]) - 3;
            }
            public int Tag
            {
                get
                {
                    return _Tag;
                }
            }
            public Enu_Tunnel_Medium_Type value
            {
                get
                {
                    byte[] temp = new byte[valuelength - 1];
                    for (int i = 0, j = 3; i < valuelength - 1; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    Enu_Tunnel_Medium_Type t = (Enu_Tunnel_Medium_Type)val;
                    return t;
                }
            }
            public enum Enu_Tunnel_Medium_Type : uint
            {
                IPv4 = 1,
                IPv6 = 2,
                NSAP = 3,
                HDLC = 4,
                BBN_1822 = 5,
                _802 = 6,
                E_163 = 7,
                E_164 = 8,
                F_69 = 9,
                X_121 = 10,
                IPX = 11,
                Appletalk = 12,
                Decnet_IV = 13,
                Banyan_Vines = 14,
                E_164_with_NSAP_format_subaddress = 15
            }
        }
        public class Tunnel_Client_Endpoint : fatherattrib
        {
            int _Tag;
            public Tunnel_Client_Endpoint(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                _Tag = attrbytes[2];
                valuelength = Convert.ToInt32(attrbytes[1]) - 3;
            }
            public int Tag
            {
                get
                {
                    return _Tag;
                }
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength - 1];
                    for (int i = 0, j = 3; i < valuelength - 1; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return Encoding.UTF8.GetString(temp);
                }
            }
        }
        public class Tunnel_Server_Endpoint : fatherattrib
        {
            int _Tag;
            public Tunnel_Server_Endpoint(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                _Tag = attrbytes[2];
                valuelength = Convert.ToInt32(attrbytes[1]) - 3;
            }
            public int Tag
            {
                get
                {
                    return _Tag;
                }
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength - 1];
                    for (int i = 0, j = 3; i < valuelength - 1; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return Encoding.UTF8.GetString(temp);
                }
            }
        }
        public class Tunnel_Password : fatherattrib // * * * * * * * * * * * * * * * * * *9 * * * * ** * **//
        {
            int _Tag;
            byte[] ra;
            string secret;
            public Tunnel_Password(byte[] attrbytes, byte[] ra, string secret)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                _Tag = attrbytes[2];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
                this.ra = ra;
                this.secret = secret;
            }
            public int Tag
            {
                get
                {
                    return _Tag;
                }
            }
            public uint Salt
            {
                get
                {
                    byte[] temp = new byte[2];
                    for (int i = 0, j = 2; i < 2; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 2; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    return val;
                }
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength-3];
                    for (int i = 0, j = 2; i < temp.Length; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return HashPassword(secret, ra, temp, Salt);
                }
            }
            private byte[] XOR(byte[] op1, byte[] op2)
            {
                byte[] res = new byte[16];
                for (int i = 0; i < 16; i++)
                {
                    res[i] = (byte)(op1[i] ^ op2[i]);
                }
                return res;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="S"> Secret key</param>
            /// <param name="R"> RA</param>
            /// <param name="OriginalPassword"> Password</param>
            /// <param name="A">Salt</param>
            /// <returns></returns>
            private string HashPassword(string S, byte[] R, byte[] OriginalPassword, uint A)
            {
                //kamel shavad
                // byte[] PBytePass = Encoding.UTF8.GetBytes(OriginalPassword);
                string result = "";
                int mylen = OriginalPassword.Length;
                int RowOfBytePass = (int)Math.Ceiling(((double)mylen) / ((double)16.0));
                byte[][] BytePass = new byte[RowOfBytePass][];
                byte[][] ByteC = new byte[RowOfBytePass][];
                byte[][] Byteb = new byte[RowOfBytePass][];
                for (int i = 0; i < RowOfBytePass; i++)
                {
                    BytePass[i] = new byte[16];
                    ByteC[i] = new byte[16];
                    Byteb[i] = new byte[16];
                    for (int j = 0; j < 16; j++)
                    {
                        BytePass[i][j] = 0;
                        ByteC[i][j] = 0;
                        Byteb[i][j] = 0;

                    }
                }

                for (int i = 0; i < mylen; i++)
                    BytePass[i / 16][i % 16] = OriginalPassword[i];
                byte[] SecretByte = Encoding.ASCII.GetBytes(S);
                for (int i = 0; i < RowOfBytePass; i++)
                {
                    byte[] temp;
                    if (i == 0)
                    {
                        temp = new byte[R.Length + SecretByte.Length+2/*salt lenght*/];
                        int j = 0;
                        for (j = 0; j < SecretByte.Length; j++)
                        {
                            temp[j] = SecretByte[j];
                        }
                        for (int k = 0; k < R.Length; k++, j++)
                        {
                            temp[j] = R[k];
                        }
                        temp[j]=(byte)(A>>8);
                        j++;
                        temp[j] = (byte)A;
                        MD5CryptoServiceProvider m = new MD5CryptoServiceProvider();
                        Byteb[0] = m.ComputeHash(temp); //b1=md5(s+R+A)
                        ByteC[0] = XOR(BytePass[0], Byteb[0]);//c0=p0 xor b0
                        string str = Encoding.ASCII.GetString(ByteC[i]);
                        result += str;
                    }
                    else
                    {
                        temp = new byte[SecretByte.Length + ByteC[i - 1].Length];
                        int j = 0;
                        for (j = 0; j < SecretByte.Length; j++)
                        {
                            temp[j] = SecretByte[j];
                        }
                        for (int k = 0; k < ByteC[i - 1].Length; k++, j++)
                        {
                            temp[j] = ByteC[i - 1][k];
                        }
                        MD5CryptoServiceProvider m = new MD5CryptoServiceProvider();
                        Byteb[i] = m.ComputeHash(temp); //bi=md5(s+c(i-1))
                        ByteC[i] = XOR(BytePass[i], Byteb[i]);//ci=pi xor bi
                        string str = Encoding.ASCII.GetString(ByteC[i]);
                        //MessageBox.Show(str);
                        result += str;
                    }
                }

                //string res = Encoding.UTF8.GetString(c1);

                //  MessageBox.Show(result);
                int nullrecognition = 0;
                for (; ; nullrecognition++)
                {
                    if (result[nullrecognition] == '\0')
                        break;
                }
                result = result.Remove(nullrecognition);
                return result;
            }
        }
        public class Tunnel_Private_Group_ID : fatherattrib
        {
            int _Tag;
            public Tunnel_Private_Group_ID(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                _Tag = attrbytes[2];
                valuelength = Convert.ToInt32(attrbytes[1]) - 3;
            }
            public int Tag
            {
                get
                {
                    return _Tag;
                }
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength - 1];
                    for (int i = 0, j = 3; i < valuelength - 1; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return Encoding.UTF8.GetString(temp);
                }
            }
        }
        public class Tunnel_Assignment_ID : fatherattrib
        {
            int _Tag;
            public Tunnel_Assignment_ID(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                _Tag = attrbytes[2];
                valuelength = Convert.ToInt32(attrbytes[1]) - 3;
            }
            public int Tag
            {
                get
                {
                    return _Tag;
                }
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength - 1];
                    for (int i = 0, j = 3; i < valuelength - 1; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return Encoding.UTF8.GetString(temp);
                }
            }
        }
        public class Tunnel_Preference : fatherattrib
        {
            int _Tag;
            public Tunnel_Preference(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                _Tag = attrbytes[2];
                valuelength = Convert.ToInt32(attrbytes[1]) - 3;
            }
            public int Tag
            {
                get
                {
                    return _Tag;
                }
            }
            public uint value
            {
                get
                {
                    byte[] temp = new byte[valuelength - 1];
                    for (int i = 0, j = 3; i < valuelength - 1; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    return val;
                }
            }
        }
        public class Tunnel_Client_Auth_ID : fatherattrib
        {
            int _Tag;
            public Tunnel_Client_Auth_ID(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                _Tag = attrbytes[2];
                valuelength = Convert.ToInt32(attrbytes[1]) - 3;
            }
            public int Tag
            {
                get
                {
                    return _Tag;
                }
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength - 1];
                    for (int i = 0, j = 3; i < valuelength - 1; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return Encoding.UTF8.GetString(temp);
                }
            }
        }
        public class Tunnel_Server_Auth_ID : fatherattrib
        {
            int _Tag;
            public Tunnel_Server_Auth_ID(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                _Tag = attrbytes[2];
                valuelength = Convert.ToInt32(attrbytes[1]) - 3;
            }
            public int Tag
            {
                get
                {
                    return _Tag;
                }
            }
            public string value
            {
                get
                {
                    byte[] temp = new byte[valuelength - 1];
                    for (int i = 0, j = 3; i < valuelength - 1; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    return Encoding.UTF8.GetString(temp);
                }
            }
        }
        public class Acct_Interim_Interval:fatherattrib
        {
            public Acct_Interim_Interval(byte[] attrbytes)
            {
                attrvalue = new byte[attrbytes.Length];
                attrvalue = (byte[])attrbytes.Clone();
                code = (AttributeCode)attrbytes[0];
                valuelength = Convert.ToInt32(attrbytes[1]) - 2;
            }
            public Acct_Interim_Interval(uint val)
            {
                attrvalue = new byte[6];
                attrvalue[0] = (byte)AttributeCode.Acct_Interim_Interval;
                attrvalue[1] = 6;
                attrvalue[5] = (byte)val;
                val = val >> 8;
                attrvalue[4] = (byte)val;
                val = val >> 8;
                attrvalue[3] = (byte)val;
                val = val >> 8;
                attrvalue[2] = (byte)val;
            }
            public uint value
            {
                get
                {
                    byte[] temp = new byte[valuelength];
                    for (int i = 0, j = 2; i < valuelength; i++, j++)
                    {
                        temp[i] = attrvalue[j];
                    }
                    uint val = temp[0];
                    for (int i = 1; i < 4; i++)
                    {
                        val = val << 8;
                        val += temp[i];
                    }
                    return val;
                }
            }
        }
    }
}
