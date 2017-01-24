using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace hw11
{
    public class Functions
    {
        public static void BinarySerialization(string fileName, Player player)
        {
            IFormatter formatter = new BinaryFormatter();
            File.WriteAllText(fileName, String.Empty);

            using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Write))
            {
                formatter.Serialize(stream, player);
            }
        }

        public static void XMLSerialization(string fileName, Player player)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Player));
            File.WriteAllText(fileName, String.Empty);

            using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Write))
            {
                xmlSerializer.Serialize(stream, player);
            }
        }

        public static void JSONSerialization(string fileName, Player player)
        {
            DataContractSerializer jsonSerializer = new DataContractSerializer(typeof(Player));
            File.WriteAllText(fileName, String.Empty);

            using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Write))
            {
                jsonSerializer.WriteObject(stream, player);
            }
        }
    }
}
