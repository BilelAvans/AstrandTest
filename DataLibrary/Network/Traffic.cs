using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

using DataLibrary;
using DataLibrary.Users;
using System.Runtime.Serialization;
using System.Reflection;

namespace DataLibrary.Network
{
    public static class Traffic
    {

        public static void sendObject(object o, Stream stream)
        {
            BinaryFormatter binary = new BinaryFormatter();

            try
            {
                binary.Serialize(stream, o);
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            stream.Flush();
        }

        public static object readObject(Stream stream)
        {
            BinaryFormatter binary = new BinaryFormatter();

            return binary.Deserialize(stream);
        }


        
    }
}
