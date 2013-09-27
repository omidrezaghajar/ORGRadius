using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace ORGRadiusBase
{
    public class ORGRadiuser
    {
        //private Packet PCObj;
        private IPEndPoint dummy;
        UdpClient responser;
        UdpClient client;
        UdpClient ClientAccount;
        int AccountingPort = 0;
        int AuthenticationPort = 0;
        public ORGRadiuser(int Authport, int AccPort)
        {
            client = new UdpClient();
            client.ExclusiveAddressUse = false;
            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            client.Client.Bind(new IPEndPoint(IPAddress.Any, 1812));
            AccountingPort = AccPort;
            AuthenticationPort = Authport;
            responser = new UdpClient();
            responser.ExclusiveAddressUse = false;
            responser.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            responser.Client.Bind(new IPEndPoint(IPAddress.Any, 1812));
            ClientAccount = new UdpClient(AccountingPort);
        }
        public void StartAuthenticationService()
        {
            Thread th = new Thread(new ThreadStart(this.Authenticator));
            th.Start();
            Thread th1 = new Thread(new ThreadStart(this.Accounter));
            th1.Start();
        }
        public class UdpState
        {
            public IPEndPoint e;
            public UdpClient u;
        }
        List<Packet> accountingpackets = new List<Packet>();
        private void Accounter()
        {
            while (true)
            {
                try
                {
                    IPEndPoint dummy = null;
                    byte[] req = ClientAccount.Receive(ref dummy);
                    this.dummy = dummy;
                    Packet PCObj = setPC(req);
                    accountingpackets.Add(PCObj);
                }
                catch { }
            }
        }
        private void Authenticator()
        {
            while (true)
            {
                try
                {
                    IPEndPoint dummy = null;
                    byte[] req = client.Receive(ref dummy);
                    this.dummy = dummy;
                    Packet PCObj = setPC(req);
                    if (PCObj.AttribObj.Username.value == "omid" && PCObj.AttribObj.UserPassword.value == "123")
                    {
                        Packet p = new Packet(PacketCode.Access_Accespt, PCObj.IdentifierOfPacket);
                        p.RAOfPacket = (byte[])PCObj.RAOfPacket.Clone();
                        p.AttribObj.ServiceType = new Attributes.Service_Type(Attributes.Service_Type.Enu_Service_Type.Framed);
                        p.listOfAttributes.Add(p.AttribObj.ServiceType);
                        p.AttribObj.FramedProtocol = new Attributes.Framed_protocol(Attributes.Framed_protocol.Enu_Framed_protocol.PPP);
                        p.listOfAttributes.Add(p.AttribObj.FramedProtocol);
                        p.AttribObj.FramedIPAddress = new Attributes.Framed_IP_Address("192.168.25.12");
                        p.listOfAttributes.Add(p.AttribObj.FramedIPAddress);
                        p.AttribObj.AcctInterimInterval = new Attributes.Acct_Interim_Interval(5);
                        p.listOfAttributes.Add(p.AttribObj.AcctInterimInterval);
                        p.AttribObj.FramedIPNetmask = new Attributes.Framed_IP_Netmask("255.255.255.0");
                        p.listOfAttributes.Add(p.AttribObj.FramedIPNetmask);
                        p.AttribObj.ReplyMessage = new Attributes.Reply_Message("welcome yaro!!!");
                        p.listOfAttributes.Add(p.AttribObj.ReplyMessage);
                        p.AttribObj.SessionTimeout = new Attributes.Session_Timeout(0);
                        p.listOfAttributes.Add(p.AttribObj.SessionTimeout);
                        SendAccessAccept(p);
                    }

                    else
                    {
                        Packet p = new Packet(PacketCode.Access_Reject, PCObj.IdentifierOfPacket);
                        p.RAOfPacket = (byte[])PCObj.RAOfPacket.Clone();
                        p.AttribObj.ReplyMessage = new Attributes.Reply_Message(".** Bad username or password **.");
                        p.listOfAttributes.Add(p.AttribObj.ReplyMessage);
                        SendAccessReject(p);
                    }
                }
                catch { }
            }
        }

        public void SendCallback(IAsyncResult ar)
        {
            responser.EndSend(ar);
        }
        private void SendResponse(byte[] array)
        {
            responser.Connect(dummy);
            responser.BeginSend(array, array.Length,
              new AsyncCallback(SendCallback), responser);
        }
        private byte[] CalcResponseRA(PacketCode pc, byte id, byte[] lengh, byte[] ReqRA, byte[] attr, byte[] secret)
        {
            byte[] temp = new byte[4 + ReqRA.Length + attr.Length + secret.Length];
            int i = 4;
            temp[0] = (byte)pc;
            temp[1] = id;
            temp[2] = lengh[0];
            temp[3] = lengh[1];
            for (int j = 0; j < ReqRA.Length; j++, i++)
                temp[i] = ReqRA[j];
            for (int j = 0; j < attr.Length; j++, i++)
                temp[i] = attr[j];
            for (int j = 0; j < secret.Length; j++, i++)
                temp[i] = secret[j];
            MD5CryptoServiceProvider m = new MD5CryptoServiceProvider();
            return m.ComputeHash(temp);
        }
        private static byte[] Concatationbytes(byte[] s1, byte[] s2)
        {
            byte[] res = new byte[s1.Length + s2.Length];
            int i;
            for (i = 0; i < s1.Length; i++)
                res[i] = s1[i];
            for (int j = 0; i < res.Length; i++, j++)
                res[i] = s2[j];
            return res;
        }
        private void SendAccessAccept(Packet pc)
        {
            byte ResCode = 2;

            int temp = 20;
            foreach (Attributes.fatherattrib f in pc.listOfAttributes)
            {
                temp += f.AttrValue.Length;
            }

            byte[] Reslengh = { Convert.ToByte(temp >> 8), Convert.ToByte(temp) };
            byte[] Response = new byte[temp];
            int temp2 = temp - 20;
            byte[] attributes = new byte[0];
            //foreach (Attributes.fatherattrib f in pc.listOfAttributes)
            //{
            //    attributes = Concatationbytes(attributes, f.AttrValue);
            //}
            for (int i = 0; i < pc.listOfAttributes.Count; i++)
            {
                Attributes.fatherattrib f = pc.listOfAttributes[i];
                attributes = Concatationbytes(attributes, f.AttrValue);
            }
            Response[0] = ResCode;
            Response[1] = Convert.ToByte(pc.IdentifierOfPacket);
            Response[2] = Reslengh[0];
            Response[3] = Reslengh[1];
            byte[] ResponseRA = CalcResponseRA(PacketCode.Access_Accespt, Convert.ToByte(pc.IdentifierOfPacket), Reslengh, pc.RAOfPacket, attributes, Encoding.ASCII.GetBytes("shaida"));
            for (int j = 4, k = 0; k < 16; j++, k++)
            {
                Response[j] = ResponseRA[k];
            }
            for (int j = 20, k = 0; k < temp - 20; j++, k++)
            {
                Response[j] = attributes[k];
            }
            //responser.Connect(dummy);
            //responser = new UdpClient(new IPEndPoint(IPAddress.Parse("192.168.1.2"), 1812));
            //responser.Send(Response,Response.Length);
            responser.Send(Response, Response.Length, dummy);
        }
        private void SendAccessReject(Packet pc)
        {
            byte ResCode = 3;

            int temp = 20;
            foreach (Attributes.fatherattrib f in pc.listOfAttributes)
            {
                temp += f.AttrValue.Length;
            }

            byte[] Reslengh = { Convert.ToByte(temp >> 8), Convert.ToByte(temp) };
            byte[] Response = new byte[temp];
            int temp2 = temp - 20;
            byte[] attributes = new byte[0];
            foreach (Attributes.fatherattrib f in pc.listOfAttributes)
            {
                attributes = Concatationbytes(attributes, f.AttrValue);
            }
            Response[0] = ResCode;
            Response[1] = Convert.ToByte(pc.IdentifierOfPacket);
            Response[2] = Reslengh[0];
            Response[3] = Reslengh[1];
            byte[] ResponseRA = CalcResponseRA(PacketCode.Access_Reject, Convert.ToByte(pc.IdentifierOfPacket), Reslengh, pc.RAOfPacket, attributes, Encoding.UTF8.GetBytes("shaida"));
            for (int j = 4, k = 0; k < 16; j++, k++)
            {
                Response[j] = ResponseRA[k];
            }
            for (int j = 20, k = 0; k < temp - 20; j++, k++)
            {
                Response[j] = attributes[k];
            }

            responser.Send(Response, Response.Length, dummy);
        }
        /// <summary>
        /// انالیزور پکت
        /// </summary>
        /// <param name="req">بسته دریافتی از شبکه</param>
        /// <returns>بسته تفکیک شده</returns>
        private Packet setPC(byte[] req)
        {
            byte Code = req[0];
            int identifier = Convert.ToInt32(req[1]);
            Packet PCObj = new Packet((PacketCode)Code, identifier);
            PCObj.AttribObj = new Attributes();
            int size = Convert.ToInt32((req[2] << 8) + req[3]);
            byte[] reqauthenticator = new byte[16];
            for (int i = 4, j = 0; i < req.Length && j < 16; i++, j++)
            {
                reqauthenticator[j] = req[i];
            }
            PCObj.RAOfPacket = reqauthenticator;
            int k = 20;
            for (; k < req.Length; ) // Type of Attributes
            {
                int AttrCode = Convert.ToInt32(req[k]);
                int AttrLength = Convert.ToInt32(req[k + 1]) - 2;
                byte[] AttrArray = new byte[AttrLength + 2];
                for (int j = k, c = 0; c < AttrLength + 2; c++, j++)
                {
                    AttrArray[c] = req[j];
                }
                switch (AttrCode)
                {

                    case 1:
                        PCObj.AttribObj.Username = new Attributes.User_Name(AttrArray);
                        //  MessageBox.Show("Username : " + value);
                        break;
                    case 2:
                        PCObj.AttribObj.UserPassword = new Attributes.User_Password(AttrArray, reqauthenticator, "shaida");
                        // MessageBox.Show("password : " + value);
                        break;
                    case 3:
                        PCObj.AttribObj.CHAPPassword = new Attributes.CHAP_Password(AttrArray);
                        break;
                    case 4:
                        string value1 = req[k + 2].ToString() + "." + req[k + 3].ToString() + "." + req[k + 4].ToString() + "." + req[k + 5].ToString();
                        AttrArray = new byte[4 + 2];
                        AttrArray[0] = 4;
                        AttrArray[1] = 6;
                        AttrArray[2] = req[k + 2];
                        AttrArray[3] = req[k + 3];
                        AttrArray[4] = req[k + 4];
                        AttrArray[5] = req[k + 5];
                        PCObj.AttribObj.NASIPAddress = new Attributes.NAS_IP_Address(AttrArray);
                        break;
                    case 5: // FOR NAS PORT
                        PCObj.AttribObj.NASPort = new Attributes.NAS_Port(AttrArray);
                        break;
                    case 6:
                        PCObj.AttribObj.ServiceType = new Attributes.Service_Type(AttrArray);
                        break;
                    case 7:
                        PCObj.AttribObj.FramedProtocol = new Attributes.Framed_protocol(AttrArray);
                        break;
                    case 8:
                        PCObj.AttribObj.FramedIPAddress = new Attributes.Framed_IP_Address(AttrArray);
                        break;
                    case 9:
                        PCObj.AttribObj.FramedIPNetmask = new Attributes.Framed_IP_Netmask(AttrArray);
                        break;
                    case 10:
                        PCObj.AttribObj.FramedRouting = new Attributes.Framed_Routing(AttrArray);
                        break;
                    case 11:
                        PCObj.AttribObj.FilterID = new Attributes.Filter_ID(AttrArray);
                        break;
                    case 12: // FOR FRAMED MTU
                        PCObj.AttribObj.FramedMTU = new Attributes.Framed_MTU(AttrArray);
                        break;
                    case 13:
                        PCObj.AttribObj.FramedCompression = new Attributes.Framed_compression(AttrArray);
                        break;
                    case 14:
                        PCObj.AttribObj.LoginIPHost = new Attributes.Login_IP_Host(AttrArray);
                        break;
                    case 15:
                        PCObj.AttribObj.LoginService = new Attributes.Login_Service(AttrArray);
                        break;
                    case 16:
                        PCObj.AttribObj.LoginTcpPort = new Attributes.Login_TCP_Port(AttrArray);
                        break;
                    case 18:
                        PCObj.AttribObj.ReplyMessage = new Attributes.Reply_Message(AttrArray);
                        break;
                    case 19:
                        PCObj.AttribObj.CallbackNumber = new Attributes.Callback_Number(AttrArray);
                        break;
                    case 20:
                        PCObj.AttribObj.CallbackId = new Attributes.Callback_Id(AttrArray);
                        break;
                    case 22:
                        PCObj.AttribObj.FramedRoute = new Attributes.Framed_Route(AttrArray);
                        break;
                    case 23:
                        PCObj.AttribObj.FramedIPXNetwork = new Attributes.Framed_IPX_Network(AttrArray);
                        break;
                    case 24:
                        PCObj.AttribObj.StateObj = new Attributes.State(AttrArray);
                        break;
                    case 25:
                        PCObj.AttribObj.ClassObj = new Attributes.Class(AttrArray);
                        break;
                    case 26:
                        PCObj.AttribObj.VendorSpecific = new Attributes.Vendor_Specific(AttrArray);
                        break;
                    case 27:
                        PCObj.AttribObj.SessionTimeout = new Attributes.Session_Timeout(AttrArray);
                        break;
                    case 28:
                        PCObj.AttribObj.IdleTimeout = new Attributes.Idle_Timeout(AttrArray);
                        break;
                    case 29:
                        PCObj.AttribObj.TerminationAction = new Attributes.Termination_Action(AttrArray);
                        break;
                    case 30:
                        PCObj.AttribObj.CalledStationId = new Attributes.Called_Station_Id(AttrArray);
                        break;
                    case 31:
                        PCObj.AttribObj.CallingStationId = new Attributes.Calling_Station_Id(AttrArray);
                        break;
                    case 32:
                        PCObj.AttribObj.NasIdentifier = new Attributes.Nas_Identifier(AttrArray);
                        break;
                    case 33:
                        PCObj.AttribObj.ProxyState = new Attributes.Proxy_State(AttrArray);
                        break;
                    case 34:
                        PCObj.AttribObj.LoginLatService = new Attributes.Login_LAT_Service(AttrArray);
                        break;
                    case 35:
                        PCObj.AttribObj.LoginLatNode = new Attributes.Login_LAT_Node(AttrArray);
                        break;
                    case 36:
                        PCObj.AttribObj.LoginLatGroup = new Attributes.Login_LAT_Group(AttrArray);
                        break;
                    case 37:
                        PCObj.AttribObj.FramedAppleTalkLink = new Attributes.Framed_AppleTalk_Link(AttrArray);
                        break;
                    case 38:
                        PCObj.AttribObj.FramedAppleTalkNetwork = new Attributes.Framed_AppleTalk_Network(AttrArray);
                        break;
                    case 39:
                        PCObj.AttribObj.FramedAppleTalkZone = new Attributes.Framed_AppleTalk_Zone(AttrArray);
                        break;
                    case 40:
                        PCObj.AttribObj.AcctStatusType = new Attributes.Acct_Status_Type(AttrArray);
                        break;
                    case 41:
                        PCObj.AttribObj.AcctDelayTime = new Attributes.Acct_Delay_Time(AttrArray);
                        break;
                    case 42:
                        PCObj.AttribObj.AcctInputOctets = new Attributes.Acct_Input_Octets(AttrArray);
                        break;
                    case 43:
                        PCObj.AttribObj.AcctOutputOctets = new Attributes.Acct_Output_Octets(AttrArray);
                        break;
                    case 44:
                        PCObj.AttribObj.AcctSessionId = new Attributes.Acct_Session_Id(AttrArray);
                        break;
                    case 45:
                        PCObj.AttribObj.AcctAuthentic = new Attributes.Acct_Authentic(AttrArray);
                        break;
                    case 46:
                        PCObj.AttribObj.AcctSessionTime = new Attributes.Acct_Session_Time(AttrArray);
                        break;
                    case 47:
                        PCObj.AttribObj.AcctInputPackets = new Attributes.Acct_Input_Packets(AttrArray);
                        break;
                    case 48:
                        PCObj.AttribObj.AccOutputPackets = new Attributes.Acct_Output_Packets(AttrArray);
                        break;
                    case 49:
                        PCObj.AttribObj.AcctTerminateCause = new Attributes.Acct_Terminate_Cause(AttrArray);
                        break;
                    case 50:
                        PCObj.AttribObj.AcctMultiSessionId = new Attributes.Acct_Multi_Session_Id(AttrArray);
                        break;
                    case 51:
                        PCObj.AttribObj.AcctLinkCount = new Attributes.Acct_Link_Count(AttrArray);
                        break;
                    case 60:
                        PCObj.AttribObj.ChapChallenge = new Attributes.CHAP_Challenge(AttrArray);
                        break;
                    case 61: // For NAS PORT TYPE
                        PCObj.AttribObj.NasPortType = new Attributes.NAS_Port_Type(AttrArray);
                        break;
                    case 62:
                        PCObj.AttribObj.PortLimit = new Attributes.Port_limit(AttrArray);
                        break;
                    case 63:
                        PCObj.AttribObj.LogiLatPort = new Attributes.Login_LAT_Port(AttrArray);
                        break;
                    case 64:
                        PCObj.AttribObj.TunnelType = new Attributes.Tunnel_Type(AttrArray);
                        break;
                    case 65:
                        PCObj.AttribObj.TunnelMediumType = new Attributes.Tunnel_Medium_Type(AttrArray);
                        break;
                    case 66:
                        PCObj.AttribObj.TunnelClientEndpoint = new Attributes.Tunnel_Client_Endpoint(AttrArray);
                        break;
                    case 67:
                        PCObj.AttribObj.TunnelServerEndpoint = new Attributes.Tunnel_Server_Endpoint(AttrArray);
                        break;
                    case 69:
                        PCObj.AttribObj.TunnelPassword = new Attributes.Tunnel_Password(AttrArray, reqauthenticator, "shaida");
                        break;
                    case 81:
                        PCObj.AttribObj.TunnelPrivateGroupID = new Attributes.Tunnel_Private_Group_ID(AttrArray);
                        break;
                    case 82:
                        PCObj.AttribObj.TunnelAssignmentID = new Attributes.Tunnel_Assignment_ID(AttrArray);
                        break;
                    case 83:
                        PCObj.AttribObj.TunnelPreference = new Attributes.Tunnel_Preference(AttrArray);
                        break;
                    case 85:
                        PCObj.AttribObj.AcctInterimInterval = new Attributes.Acct_Interim_Interval(AttrArray);
                        break;
                    case 90:
                        PCObj.AttribObj.TunnelClientAuthID = new Attributes.Tunnel_Client_Auth_ID(AttrArray);
                        break;
                    case 91:
                        PCObj.AttribObj.TunnelServerAuthID = new Attributes.Tunnel_Server_Auth_ID(AttrArray);
                        break;

                    //case 5:
                    //case 12:
                    //case 61:
                    //    long l = req[k + 2];
                    //    for (int i = 0; i < 3; i++)
                    //        l = (l << 8) + req[k + 2 + i + 1]; // Shift 1 byte 1 byte
                    //    string value2 = l.ToString();
                    //    AttrArray = new byte[AttrLength + 2];
                    //    for (int j = k, c = 0; c < AttrLength + 2; c++, j++)
                    //    {
                    //        AttrArray[c] = req[j];
                    //    }
                    //    switch (AttrCode)
                    //    {




                    // }
                    //   break;
                }
                k += AttrLength + 2;
            }
            // uint lk = PCObj.AttribObj.NASPort.value;

            return PCObj;
        }
        //private string stringsAttributeSpliter(byte[] Attrib)
        //{
        //    //attrvalue = new byte[attrbytes.Length];
        //    //attrvalue = (byte[])attrbytes.Clone();
        //    //code = (AttributeCode)attrbytes[0];
        //    //valuelength = Convert.ToInt32(attrbytes[1]) - 2;
        //    //byte[] temp = new byte[valuelength];
        //    //for (int i = 0, j = 2; i < valuelength; i++, j++)
        //    //{
        //    //    temp[i] = Attrib[j];
        //    //}
        //    //return Encoding.UTF8.GetString(temp);
        //}
    }
    
}
