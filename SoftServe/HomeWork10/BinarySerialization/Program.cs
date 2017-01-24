using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace BinarySerialization
{
    class Program
    {
        public static string GetPath(string fileName)
        {
            var directory = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            return Path.Combine(directory, fileName);
        }

        private static void BinarySerialization(string fileName, Person[] person)
        {
            IFormatter formatter = new BinaryFormatter();

            using (Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(stream, person);
            }
        }

        private static void XmlSerialization(string fileName, Person[] person)
        {
            XmlSerializer formatterXml = new XmlSerializer(typeof(Person[]));

            using (Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                formatterXml.Serialize(stream, person);
            }
        }

        private static void JsonSerialization(string fileName, Person[] person)
        {
            DataContractJsonSerializer formatterJson = new DataContractJsonSerializer(typeof(Person[]));

            using (Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                formatterJson.WriteObject(stream, person);
            }
        }

        static void Main(string[] args)
        {
            Person person = new Person
            {
                FirstName = "Jonh",
                LastName = "Smith",
                Age = 33,
                Country = "UK",
                City = "London"
            };

            Person person1 = new Person
            {
                FirstName = "Massimo",
                LastName = "Peruzzi",
                Age = 28,
                Country = "Italy",
                City = "Torino"
            };

            Person[] persons = new Person[] { person, person1 };

            var binFilePath = GetPath("Persons.bin");
            var xmlFilePath = GetPath("Persons.xml");
            var jsonFilePath = GetPath("Persons.json");

            BinarySerialization(binFilePath, persons);
            XmlSerialization(xmlFilePath, persons);
            JsonSerialization(jsonFilePath, persons);

            Console.ReadKey();
        }
    }
}
