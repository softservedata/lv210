using System.IO;
using System.Xml.Serialization;

namespace Serialization
{
    public class SerializationXML
    {
        public void SerializeToXML(Me me, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Me));

            using (Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                serializer.Serialize(stream, me);
            }
        }
    }
}
