using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Packets
{
    [Serializable]
    public class JSONPacket: Packet
    {
        public JSONPacket(object JSONObject): base()
        {
            this.data = new object[] { JsonConvert.SerializeObject(JSONObject) };
        }

        public object Deserialize()
        {
            return JsonConvert.DeserializeObject((string)this.data[0]);
        }
    }
}
