using System.Linq;
using System.IO;

namespace StringTask
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
        internal void WriteData(string fileName, string[] data)
        {
            var lines = data.Select(line => $"{line} - {line.Length}").ToArray();
            File.WriteAllLines(fileName, lines);
        }

        //Number of elements
        internal void WriteStringCount(string[] data)
        {
            WriteData("StringCount.txt", data.Select(line => line.Length).ToArray());
        }

        //Longest string
        internal void SearchAndWriteLongestString(string[] data)
        {
            var maxLength = data.Max(x => x.Length);
            WriteData("SearchAndWriteLongestString.txt", data.Where(x => x.Length == maxLength).ToArray());
        }

        //Shortest string
        internal void SearchAndWriteShortestString(string[] data)
        {
            var minLength = data.Min(x => x.Length);
            WriteData("SearchAndWriteShortestString.txt", data.Where(x => x.Length == minLength).ToArray());
        }

        //String that contains substring
        internal void SearchAndWriteSpecificString(string[] data, string value)
        {
            var lines = data.Where(x => x.Contains(value)).ToArray();
            WriteData("SearchAndWriteSpecificString.txt", lines);
        }
        //delegates!
    }
}
