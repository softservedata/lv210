using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Wow.Data
{
    public class XmlUtil: IExternalData
    {
        private const string XPATH_FOR_USER_NODE = "/ArrayOfUsers/User";
        private string[] tagNames;

        public IList<IList<string>> GetAllValues(string path)
        {
            XmlDocument xmlFile = new XmlDocument();
            xmlFile.Load(path);
            TagNames(xmlFile);
            IList<IList<string>> allValues = new List<IList<string>>();
            XmlNodeList objectNodes = xmlFile.SelectNodes(XPATH_FOR_USER_NODE);
            
            foreach (XmlNode node in objectNodes)
            {
                string[] line = new string[tagNames.Length];
                for (int i = 0; i < tagNames.Length; i++)
                {
                    line[i] = node[tagNames[i]].InnerText;
                }
                allValues.Add(line.ToList());
            }
            return allValues;
        }

        private void TagNames(XmlDocument xmlFile)
        {
            XmlNode objectNode = xmlFile.DocumentElement.FirstChild;
            int tagsNumber = objectNode.ChildNodes.Count;
            tagNames = new string[tagsNumber];

            for (int i = 0; i < tagsNumber; i++)
            {
                tagNames[i] = objectNode.ChildNodes[i].LocalName;
            }
        }
    }
}
