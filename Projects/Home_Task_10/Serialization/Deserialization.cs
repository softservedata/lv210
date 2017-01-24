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
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(fileName, FileMode.Open);
            IEnumerable<Person> collection = (IEnumerable<Person>)formatter.Deserialize(stream);
            stream.Close();
            return collection;
        }

        public static IEnumerable<Person> Xml(string fileName)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(List<Person>));
            Stream stream = new FileStream(fileName, FileMode.Open);
            IEnumerable<Person> collection = (IEnumerable<Person>)xmlser.Deserialize(stream);
            stream.Close();
            return collection;
        }

        public static IEnumerable<Person> Json(string fileName)
        {
            DataContractJsonSerializer jsonser = new DataContractJsonSerializer(typeof(List<Person>));
            Stream stream = new FileStream(fileName, FileMode.Open);
            IEnumerable<Person> collection = (IEnumerable<Person>)jsonser.ReadObject(stream);
            stream.Close();
            return collection;
        }
    }
}
