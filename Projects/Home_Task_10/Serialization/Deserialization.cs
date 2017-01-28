using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
    public static class Deserialization
    {
        public static IEnumerable<Person> Binary(string fileName)
        {
            IEnumerable<Person> collection;
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(fileName, FileMode.Open))
            {
               collection = (IEnumerable<Person>)formatter.Deserialize(stream);
            }
            return collection;
        }

        public static IEnumerable<Person> Xml(string fileName)
        {
            IEnumerable<Person> collection;
            XmlSerializer xmlser = new XmlSerializer(typeof(List<Person>));
            using (Stream stream = new FileStream(fileName, FileMode.Open))
            {
                collection = (IEnumerable<Person>)xmlser.Deserialize(stream);
            }
            return collection;
        }

        public static IEnumerable<Person> Json(string fileName)
        {
            IEnumerable<Person> collection;
            DataContractJsonSerializer jsonser = new DataContractJsonSerializer(typeof(List<Person>));
            using (Stream stream = new FileStream(fileName, FileMode.Open))
            {
                collection = (IEnumerable<Person>)jsonser.ReadObject(stream);
            }
            return collection;
        }
    }
}
