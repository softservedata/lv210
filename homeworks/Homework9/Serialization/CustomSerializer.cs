using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Serialization
{
    class CustomSerializer
    {
        public static void SerializeToXML(Person person, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Person));

            using (Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                serializer.Serialize(stream, person);
            }
        }

        public static void SerializeToBinary(Person person, string fileName)
        {
            IFormatter formatter = new BinaryFormatter();

            using (Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, person);
            }
        }

        public static void SerializeToJSON(Person person, string fileName)
        {
            DataContractSerializer jsonSerializer = new DataContractSerializer(typeof(Person));

            using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Write))
            {
                jsonSerializer.WriteObject(stream, person);
            }
        }
    }
}
