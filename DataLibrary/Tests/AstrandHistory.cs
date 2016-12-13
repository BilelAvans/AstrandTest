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
        
        public AstrandHistory(string filename, DateTime start, DateTime end, List<Measurement> measurements, AstrandResults results)
        {
            this.Start = start;
            this.End = end;
            this.Measurements = measurements;
            this.Results = results;
            this.Name = filename;
        }

        public static bool loadFile(out AstrandHistory aHistory, string filename)
        {
            FileStream file = File.OpenRead(@"..\..\History\" + filename);
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

            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            file.Close();
            aHistory = null;


            return false;
        }

        public bool saveFile()
        {

            FileStream file;

            if (!File.Exists(@"..\..\History\" + Name))
                file = File.Create(@"..\..\History\" + Name);
            else
                file = File.Open(@"..\..\History\" + Name, FileMode.Open);

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
            File.Delete(@"..\..\History\" + Name);
        }
        // Get all files in set directory
        public static List<AstrandHistory> GetHistory()
        {
            List<AstrandHistory> History = new List<AstrandHistory>();

            if (Directory.Exists(@"..\..\History\"))
            {
                string[] dir = Directory.GetFiles(@"..\..\History\");

                dir.ToList().ForEach(filename =>
                {
                    AstrandHistory history;
                    if (AstrandHistory.loadFile(out history, filename.Split('\\')[filename.Split('\\').Count() - 1]))
                    {
                        History.Add(history);
                    }

                });

            }

            return History;

        }


    }
}
