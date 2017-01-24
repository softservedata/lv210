using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace hw11
{
    [Serializable]
    [DataContract]
    public class Player
    {
        [DataMember]
        [XmlAttribute]
        public string Name { get; set; }

        [DataMember]
        [XmlAttribute]
        public DateTime dateOfDeath { get; set; }

        [DataMember]
        [XmlAttribute]
        public int score { get; set; }
        
        public Player()
        {
            Name = "Player";
            dateOfDeath = DateTime.Now;
            score = 0;
        }
    }
}
