using System.Linq;
using System.IO;

namespace LinQTasks
{
    public class FileOperations
    {
        //Write data
        public void WriteData(string fileName, int[] data)
        {
            var lines = data.Select(value => value.ToString()).ToArray();
            File.WriteAllLines(fileName, lines);
        }

        //Write data
        public void WriteData(string fileName, string[] data)
        {
            var lines = data.Select(line => $"{line} - {line.Length}").ToArray();
            File.WriteAllLines(fileName, lines);
        }

        //Number of elements
        public void StringCount(string[] data)
        {
            WriteData("StringCount.txt", data.Select(line => line.Length).ToArray());
        }

        //Longest string
        public void LongestString(string[] data)
        {
            var maxLength = data.Max(x => x.Length);
            WriteData("LongestString.txt", data.Where(x => x.Length == maxLength).ToArray());
        }

        //Shortest string
        public void ShortestString(string[] data)
        {
            var minLength = data.Min(x => x.Length);
            WriteData("ShortestString.txt", data.Where(x => x.Length == minLength).ToArray());
        }

        //String that contains substring
        public void SearchString(string[] data, string value)
        {
            var lines = data.Where(x => x.Contains(value)).ToArray();
            WriteData("SearchString.txt", lines);
        }
    }
}
