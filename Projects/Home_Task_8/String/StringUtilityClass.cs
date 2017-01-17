using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String
{
    public static class StringUtilityClass
    {
        public static string GetFilePathFromDesktop(string fileName)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
        }

        public static string GetFileBySpecifiedPath(string pathToDirectory, string fileName)
        {
            return Path.Combine(pathToDirectory, fileName);
        }

        public static string[] GetEachLineLengthInfo(this string[] textContent)
        {
            return textContent.Select((line,index) => $"Line #{index+1} has {line.Length} symbols.").ToArray();
        }

        public static void WriteToFile(this string[] textContent, string fileName, string title)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(title);
                foreach (var line in textContent)
                {
                    writer.WriteLine(line.ToString());
                }
                writer.WriteLine($"Mod: {DateTime.Now} {Environment.NewLine}");
            }
        }

        public static void DisplayOnConsole(this IEnumerable<string> resultArray)
        {
            foreach (var line in resultArray)
                Console.WriteLine(line);
        }

        public static string[] GetLongestLines(this string[] textContent)
        {
            return textContent.Where(line =>
            line.Length == textContent.Max(item => item.Length)).ToArray();
        }

        public static string[] GetShortestLines(this string[] textContent)
        {
            return textContent.Where(line =>
            line.Length == textContent.Min(item => item.Length)).ToArray();
        }

        public static string[] GetLinesContainsSubstring(this string[] textContent, string substring)
        {
            return textContent.Where(item =>
            item.ToLower().Contains(substring.ToLower())).ToArray();
        }
    }
}
