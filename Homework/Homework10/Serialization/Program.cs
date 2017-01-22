using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Serialization
{
    class Program
    {
        public static string GetPath(string fileName)
        {
            var directory = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            return Path.Combine(directory, fileName);
        }

        public static void BinarySerialization(string fileName, Person person)
        {
            IFormatter formatter = new BinaryFormatter();
            File.WriteAllText(fileName, String.Empty);
            using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Write))
            {
                formatter.Serialize(stream, person);
            }
        }

        public static void XMLSerialization(string fileName, Person person)
        {
            XmlSerializer xmlSer = new XmlSerializer(typeof(Person));
            File.WriteAllText(fileName, String.Empty);
            using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Write))
            {
                xmlSer.Serialize(stream, person);
            }
        }

        public static void JSONSerialization(string fileName, Person person)
        {
            DataContractSerializer jsonSer = new DataContractSerializer(typeof(Person));
            File.WriteAllText(fileName, String.Empty);
            using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Write))
            {
                jsonSer.WriteObject(stream, person);
            }
        }

        static void Main(string[] args)
        {
            Person person = new Person
            {
                Name = "Ivan",
                Surname = "Kozak",
                GenderState = Gender.Male,
                DateOfBirth = new DateTime(1996, 10, 1),
                MaritalStat = MaritalStatus.Single,
                PassportDetails = "КС 118890"
            };

            var pathToBinFile = GetPath("SerializedPersonToBinFile.bin");
            var pathToXmlFile = GetPath("SerializedPersonToXml.xml");
            var pathToJsonFile = GetPath("SerializePersonToJson.json");

            BinarySerialization(pathToBinFile, person);
            XMLSerialization(pathToXmlFile, person);
            JSONSerialization(pathToJsonFile, person);
        }
    }
}
