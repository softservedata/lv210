using System.IO;

namespace StringTask
{
    internal class Program
    {
        //Read data
        public static string[] ReadData(string fileName)
        {
            return File.ReadAllLines(fileName);
        }

        private static void Main()
        {
            var data = ReadData("hp1.txt");
            var fileData = new FileOperations();
            const string stringToFind = "wand";

            fileData.WriteStringCount(data);
            fileData.SearchAndWriteLongestString(data);
            fileData.SearchAndWriteShortestString(data);
            fileData.SearchAndWriteSpecificString(data, stringToFind);
        }
    }
}