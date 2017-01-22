using System.IO;
using System.Linq;

namespace TaskWithString
{
    internal class Program
    {
        private static string[] ReadDataFromFile(string fileName)
        {
            return File.ReadAllLines(fileName);
        }

        private static void WriteDataToFile(string fileName, int[] data)
        {
            var lines = data.Select(value => value.ToString()).ToArray();
            File.WriteAllLines(fileName, lines);
        }

        private static void WriteDataToFile(string fileName, string[] data)
        {
            var lines = data.Select(line => $"{line} - {line.Length}").ToArray();
            File.WriteAllLines(fileName, lines);
        }

        private static int[] FindCountOfElementsInAllStrings(string[] data)
        {
            return data.Select(line => line.Length).ToArray();
        }

        private static string[] FindTheLongestStringsInArray(string[] data)
        {
            var maxLength = data.Max(x => x.Length);
            return data.Where(x => x.Length == maxLength).ToArray();
        }

        private static string[] FindTheShortestStringsInArray(string[] data)
        {
            var minLength = data.Min(x => x.Length);
            return data.Where(x => x.Length == minLength).ToArray();
        }

        private static string[] FindAllStringsInArrayWithAppropriateSubString(string[] data, string value)
        {
            return data.Where(x => x.Contains(value)).ToArray();
        }

        static void Main()
        {
            var data = ReadDataFromFile("testFile.txt");

            var lengthValues = FindCountOfElementsInAllStrings(data);
            WriteDataToFile("lengthValues.txt", lengthValues);

            var maxLengthLines = FindTheLongestStringsInArray(data);
            WriteDataToFile("maxLengthLine.txt", maxLengthLines);

            var minLengthLines = FindTheShortestStringsInArray(data);
            WriteDataToFile("minLengthLine.txt", minLengthLines);

            var allLinesThatContainsValue = FindAllStringsInArrayWithAppropriateSubString(data, "var");
            WriteDataToFile("allLinesThatContainsValue.txt", allLinesThatContainsValue);
        }
    }
}