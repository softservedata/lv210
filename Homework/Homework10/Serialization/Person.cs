using System;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Serialization
{
    public enum MaritalStatus {Single, Maried, Divorsed, Separated, Widowed}
    public enum Gender { Male, Female}

    [Serializable]
    [DataContract]
    public class Person
    {
        private const string Pattern = @"^[А-Я]{2}\s\d{6}$";

        [NonSerialized]
        private string passportDetails;
        [XmlAttribute(AttributeName= "Name")]
        [DataMember(Name = "name", Order = 1)]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "Surname")]
        [DataMember(Name = "surname", Order = 2)]
        public string Surname { get; set; }
        [DataMember(Name = "gender", Order = 3)]
        public Gender GenderState { get; set; }
        [DataMember(Name = "dateOfBirth", Order = 4)]
        public DateTime DateOfBirth { get; set; }
        [DataMember(Name = "maritalState", Order = 5)]
        public MaritalStatus MaritalStat { get; set; }

        [XmlIgnore]
        public string PassportDetails
        {
            get { return passportDetails; }
            set
            {
                Regex rgx = new Regex(Pattern);
                Match match = rgx.Match(value);

                if (match == Match.Empty)
                {
                    throw new ArgumentException("Incorrect format of passport data!");
                }

                passportDetails = value;
            }
        }

        public void ChangeName(string name)
        {
            this.Name = name;
        }

        public int Age()
        {
            return DateTime.Now.Year - DateOfBirth.Year;
        }

        public override string ToString()
        {
            return $"Name - {this.Name}, age - {this.Age()}";
        }
    }
}
