using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class PhoneNumberBook
    {
        Dictionary<string,string> phoneNumberList;

        public PhoneNumberBook() 
        {
            this.phoneNumberList = new Dictionary<string, string>();
            
        }
        public void readDataFromTheFile(string pathToTheSourceFile, string sourceFileName)
        {
            StreamReader reader = new StreamReader(pathToTheSourceFile + sourceFileName);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] phonePairs = line.Split('-');
                phoneNumberList.Add(phonePairs[0].Trim(), phonePairs[1].Trim());
            }
        }
        public void writeNumbersToTheFile(string pathToTheDestinationFile, string destinationFileName)
        {
            using (StreamWriter writer = new StreamWriter(pathToTheDestinationFile + destinationFileName))
            {
                foreach (KeyValuePair<string, string> item in phoneNumberList)
                {
                    writer.WriteLine(item.Value);
                }
            }
        }

        public void writeDataToTheFile(string pathToTheDestinationFile, string destinationFileName)
        {
            using (StreamWriter writer = new StreamWriter(pathToTheDestinationFile + destinationFileName))
            {
                foreach (KeyValuePair<string, string> item in phoneNumberList)
                {
                    writer.WriteLine(item.Key+" "+item.Value);
                }
            }
        }

        public void printToConsole()
        {
            foreach (KeyValuePair<string, string> item in phoneNumberList)
            {
                Console.WriteLine("{0} has number {1}", item.Key, item.Value);
            }
        }
        public string findPhoneNumberByPersonsName(string name) { 
             
            foreach (KeyValuePair<string, string> item in phoneNumberList)
            {
                if (item.Key == name)
                {
                    return item.Value;
                }
            }
            return null;
        }
        public void changeFormatNumbers() {

            Dictionary<string, string> tmpList = new Dictionary<string, string>(phoneNumberList);

            foreach (KeyValuePair<string, string> item in tmpList)
            {
                if (item.Value.Substring(0, 2) == "80")
                {
                    phoneNumberList[item.Key] = "+3" + item.Value;
                }
            }
        }
    }
}
