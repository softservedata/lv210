using System.IO;

namespace StringTask
{
    internal class Program
    {
        //Read data
        private static string[] ReadData(string fileName)
        {
            return File.ReadAllLines(fileName);
        }

        private static void WorkWithMethods(string[] data)
        {
            var fileData = new FileOperations();
            const string stringToFind = "wand";

            fileData.WriteStringCount(data);
            fileData.SearchAndWriteLongestString(data);
            fileData.SearchAndWriteShortestString(data);
            fileData.SearchAndWriteSpecificString(data, stringToFind);
        }

        private static void Main()
        {
            var data = ReadData("hp1.txt");
            WorkWithMethods(data);
        }
    }
}