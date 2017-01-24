using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Person> persons = new List<Person>
            {
                new Person(1, "LeBron", "James", 32, "Cleveland"),
                new Person(2, "Derrick", "Rose", 28, "New York"),
                new Person(3, "Allen", "Iverson", 41, "Philadelphia"),
            };

            // Binary
            string fileName = "persons";
            Serialization.Binary(persons, $"{fileName}.bin");
            IEnumerable<Person> readPersons = Deserialization.Binary($"{fileName}.bin");
            WriteToFile(readPersons, $"{fileName}.txt", title: "Deserialize from binary");

            // Xml
            Serialization.Xml(persons, $"{fileName}.xml");
            readPersons = Deserialization.Xml($"{fileName}.xml");
            WriteToFile(readPersons, $"{fileName}.txt", title: "Deserialize from XML");

            // Json
            Serialization.Json(persons, $"{fileName}.json");
            readPersons = Deserialization.Json($"{fileName}.json");
            WriteToFile(readPersons, $"{fileName}.txt", title: "Deserialize from JSON");
        }

        public static void WriteToFile(IEnumerable<Person> persons, string fileName, string title)
        {
            File.AppendAllText(fileName, $"{title}\r\n");
            foreach (var person in persons)
                File.AppendAllText(fileName, $"{person}\r\n");
        }
    }
}
