using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw11
{
    public class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player()
            {
                Name = "Oleg",
                dateOfDeath = DateTime.Now,
                score = 9999          
            };

            var nameOfBinFile = "SerializedPersonToBinFile.bin";
            var nameOfXmlFile = "SerializedPersonToXml.xml";
            var nameOfJsonFile = "SerializePersonToJson.json";

            Functions.BinarySerialization(nameOfBinFile, player);
            Functions.XMLSerialization(nameOfXmlFile, player);
            Functions.JSONSerialization(nameOfJsonFile, player);
        }
     
        
    }
}
