namespace Serialization
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Me Andrii = new Me("Andrii", "Tester", 28);
            SerializationBinary toBinary = new SerializationBinary();
            SerializationXML toXML = new SerializationXML();
            SerializationJSON toJSON = new SerializationJSON();

            toJSON.SerializeToJSON(Andrii, "toJson");
            toXML.SerializeToXML(Andrii, "toXml");
            toBinary.SerializeToBinary(Andrii, "toBinary");
        }
    }
}
