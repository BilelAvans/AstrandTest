using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Packets
{
    [Serializable]
    public class LoginPacket: Packet
    {

        public bool A { get; set; }

        public LoginPacket(string name, string pw)
        {
            this.data = new object[] { name, pw, null };
        }

    }
}
