using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public static class Serialization
    {
        public static void Binary(IEnumerable<Person> collection, string fileName)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(fileName, FileMode.Create);
            formatter.Serialize(stream, collection);
            stream.Close();
        }

        public static void Xml(IEnumerable<Person> collection, string fileName)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(List<Person>));
            Stream stream = new FileStream(fileName, FileMode.Create);
            xmlser.Serialize(stream, collection);
            stream.Close();
        }

        public static void Json(IEnumerable<Person> collection, string fileName)
        {
            DataContractJsonSerializer jsonser = new DataContractJsonSerializer(typeof(List<Person>));
            Stream stream = new FileStream(fileName, FileMode.Create);
            jsonser.WriteObject(stream, collection);
            stream.Close();
        }
    }
}
