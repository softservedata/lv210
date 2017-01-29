using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Wow.Data;
using System.Xml.Serialization;
using System.Web;

namespace beta
{
    class Program
    {
        static void Main(string[] args)
        {
            //IList<User> users = new List<User>
            //    {
            //        User.Get()
            //        .SetFirstName("LV-204")
            //        .SetLastName("ISTQB")
            //        .SetLanguage("English")
            //        .SetEmail("wowira@ukr.net")
            //        .SetPassword("irawow123")
            //        .SetIsAdmin(true)
            //        .SetIsTeacher(true)
            //        .SetIsStudent(true)
            //        .Build(),

            //        User.Get()
            //        .SetFirstName("aaaaaa")
            //        .SetLastName("aaaaaa")
            //        .SetLanguage("English")
            //        .SetEmail("k2854799@mvrht.com")
            //        .SetPassword("qwerty+1")
            //        .SetIsAdmin(false)
            //        .SetIsTeacher(false)
            //        .SetIsStudent(true)
            //        .Build()
            //};


            //IList<User> users = new List<User>();
            //users =  XmlUtil.GetAllUsers("Users.xml");

            //foreach (var user in users)
            //{
            //    Console.WriteLine(user.GetFullName());
            //    Console.WriteLine(user.GetPassword());
            //    Console.WriteLine(user.GetEmail());
            //}
            //string[] arr;
            //XmlDocument xml = new XmlDataDocument();
            //xml.Load("Users.xml");


            //foreach (XmlNode node in xml.DocumentElement.ChildNodes)
            //{
            //    Console.WriteLine(node.LocalName);
            //}

            //XmlElement elem = (XmlElement)xml.DocumentElement;
            //Console.Write("{0} = {1}", elem.Name, elem.InnerText);
            //Console.WriteLine("\t namespaceURI=" + elem.NamespaceURI);

            //XmlDocument doc = new XmlDocument();
            //doc.Load("Users.xml");

            //// Get and display all the book titles.
            //XmlElement root = doc.DocumentElement;
            //XmlNodeList elemList = root.GetElementsByTagName("firstName");
            //for (int i = 0; i < elemList.Count; i++)
            //{
            //    Console.WriteLine(elemList[i].LocalName);
            //}

            //XmlDocument xml = new XmlDataDocument();
            //xml.Load("Users.xml");

            //XmlNode users = xml.DocumentElement.FirstChild;
            //string[] tags = new string[users.ChildNodes.Count];

            //Console.WriteLine("------");

            //for (int i = 0; i < users.ChildNodes.Count; i++)
            //{

            //    tags[i] = users.ChildNodes[i].LocalName;
            //}


            //IList<IList<string>> allValues = new List<IList<string>>();


            //XmlNodeList xnList = xml.SelectNodes("/ArrayOfUsers/User");
            //foreach (XmlNode xn in xnList)
            //{
            //    string[] line = new string[tags.Length];
            //    for (int i = 0; i < tags.Length; i++)
            //    {
            //        line[i] = xn[tags[i]].InnerText;
            //        Console.Write($"{xn[tags[i]].InnerText};");
            //    }

            //    allValues.Add(line.ToList());
            //    Console.WriteLine();
            //}

            //IList<IUser>

            // TODO TODO TODO TODO
            //foreach (XmlNode xn in xnList)
            //{
            //    string firstName = xn["firstName"].InnerText;
            //    string lastName = xn["lastName"].InnerText;
            //    string language = xn["language"].InnerText;
            //    string email = xn["email"].InnerText;
            //    string password = xn["password"].InnerText;
            //    string isAdmin = xn["isAdmin"].InnerText;
            //    string isTeacher = xn["isTeacher"].InnerText;
            //    string isStudent = xn["isStudent"].InnerText;
            //    Console.WriteLine($"{firstName} {lastName} {language} {email} {password} {isAdmin} {isStudent} {isTeacher}");
            //}

            //IUser s = JsonUtils.xGetAllUsers("Users.json").GetAdmin();
            //Console.WriteLine(s.GetFullName());

        }
    }
}
