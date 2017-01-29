using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization
{
    public class SerializationBinary
    {
        public void SerializeToBinary(Me me, string fileName)
        {
            IFormatter formatter = new BinaryFormatter();

            using (Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, me);
            }
        }
    }
}
