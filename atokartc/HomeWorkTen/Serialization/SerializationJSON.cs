using System.IO;
using System.Runtime.Serialization;

namespace Serialization
{
    public class SerializationJSON
    {
        public void SerializeToJSON(Me me, string fileName)
        {
            DataContractSerializer jsonSer = new DataContractSerializer(typeof(Me));

            using (Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                jsonSer.WriteObject(stream, me);
            }
        }
    }
}
