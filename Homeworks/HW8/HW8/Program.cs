using System.IO;

namespace LinQTasks
{
    class Program
    {
        //Read data
        public static string[] ReadData(string fileName)
        {
            return File.ReadAllLines(fileName);
        }

        static void Main()
        {
            var data = ReadData("hp1.txt");
            FileOperations fileData = new FileOperations();

            fileData.StringCount(data);
            fileData.LongestString(data);
            fileData.ShortestString(data);
            fileData.SearchString(data, "wand");
        }
    }
}