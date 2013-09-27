using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORGRadiusBase
{
    public class Packet
    {
        public Attributes AttribObj;
        private PacketCode _codeOfPacket;
        private int _identifierOfPacket;
        public List<Attributes.fatherattrib> listOfAttributes= new List<Attributes.fatherattrib>();
        private byte[] _RAOfPacket; // Authenticator of Packet
        public Packet(PacketCode PC,int identity)
        {
            AttribObj = new Attributes();
            RAOfPacket = new byte[16];
            codeOfPacket = PC;
            _identifierOfPacket = identity;
        }
        public byte[] RAOfPacket
        {
            set
            {
                _RAOfPacket = value;
            }
            get
            {
                return _RAOfPacket;
            }
        }
        public PacketCode codeOfPacket
        {
            set
            {
                _codeOfPacket = value;
            }
            get
            {
                return _codeOfPacket;
            }
        }
        public int IdentifierOfPacket
        {
            get
            {
                return _identifierOfPacket;
            }
        }
       
    }
}
