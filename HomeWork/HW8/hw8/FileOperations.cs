using System.Linq;
using System.IO;

namespace hw8
{
    public class FileOperations
    {
        public static string[] ReadDataFromFile(string fileName)
        {
            return File.ReadAllLines(fileName);
        }

        public void WriteData(string fileName, int[] data)
        {
            var lines = data.Select(value => value.ToString()).ToArray();
            File.WriteAllLines(fileName, lines);
        }

        public void WriteData(string fileName, string[] data)
        {
            var lines = data.Select(line => $"{line} - {line.Length}").ToArray();
            File.WriteAllLines(fileName, lines);
        }


        public void CountOfString(string[] data)
        {
            WriteData("CountOfString.txt", data.Select(line => line.Length).ToArray());
        }


        public void FindLongestLine(string[] data)
        {
            var maxLength = data.Max(x => x.Length);
            WriteData("LongestLine.txt", data.Where(x => x.Length == maxLength).ToArray());
        }

 
        public void FindShortestLine(string[] data)
        {
            var minLength = data.Min(x => x.Length);
            WriteData("ShortestLine.txt", data.Where(x => x.Length == minLength).ToArray());
        }

        public void SearchStringWithAppropriateSubstring(string[] data, string value)
        {
            var lines = data.Where(x => x.Contains(value)).ToArray();
            WriteData("LineWithSubstring.txt", lines);
        }
    }
}
