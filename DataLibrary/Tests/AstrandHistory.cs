using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using static DataLibrary.Tests.AstrandWrapper;

namespace DataLibrary.Tests
{
    [Serializable]
    public class AstrandHistory
    {
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public List<Measurement> Measurements { get; set; } = new List<Measurement>();

        public AstrandResults Results { get; set; }

        private string _username;
        
        public AstrandHistory(string username, DateTime start, DateTime end, List<Measurement> measurements, AstrandResults results)
        {
            this.Name = DateTime.Now.ToString("dd-MM-yyyy HH-mm") + ".rslt";

            this.Start = start;
            this.End = end;
            this.Measurements = measurements;
            this.Results = results;
            this._username = username;
        }

        public static bool loadFile(out AstrandHistory aHistory, string username, string filename)
        {

            if (Directory.Exists(@"..\..\History\" + username + " "))
            {

                FileStream file = File.OpenRead(@"..\..\History\" + username + "\\" + filename);

                try
                {
                    BinaryFormatter deserializer = new BinaryFormatter();
                    object ob = deserializer.Deserialize(file);
                    if (ob is AstrandHistory)
                    {
                        aHistory = (AstrandHistory)ob;

                        file.Close();
                        return true;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                file.Close();
                
            }

            aHistory = null;
            return false;
        }

        public bool saveFile()
        {
            if (!Directory.Exists(@"..\..\History\" + _username + " "))
                Directory.CreateDirectory(@"..\..\History\" + _username);
            
            FileStream file;

            if (!File.Exists(@"..\..\History\" + _username))
            {

                file = File.Create(@"..\..\History\" + _username + "\\" + Name);
            }
            else
                file = File.Open(@"..\..\History\" + _username + "\\" + Name, FileMode.OpenOrCreate);
            
            try
            {
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(file, this);

            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            
            file.Close();

            return true;
        }       

        public void delete()
        {
            File.Delete(@"..\..\History\" + _username + "\\" + Name);
        }
        // Get all files in set directory
        public static List<AstrandHistory> GetHistory(string username)
        {
            if (!Directory.Exists(@"..\..\History\" + username))
                Directory.CreateDirectory(@"..\..\History\" + username);

            List<AstrandHistory> History = new List<AstrandHistory>();

            if (Directory.Exists(@"..\..\History\" + username + "\\"))
            {
                string[] dir = Directory.GetFiles(@"..\..\History\" + username + "\\");

                dir.ToList().ForEach(filename =>
                {
                    AstrandHistory history;
                    if (AstrandHistory.loadFile(out history, username, filename.Split('\\')[filename.Split('\\').Count() - 1]))
                    {
                        History.Add(history);
                    }

                });

            }

            return History;

        }


    }
}
