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
        public static string GetFileFromDesktop(string fileName)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
        }

        public static string GetFileBySpecifiedPath(string pathToDirectory, string fileName)
        {
            return Path.Combine(pathToDirectory, fileName);
        }

        public static void ConsoleDisplaySymbolsInEachLine(this string[] textContent)
        {
            int lineNumber = 1;

            foreach (var line in textContent)
            {
                Console.WriteLine($"Line #{lineNumber} has {line.Length} symbols.");
                lineNumber++;
            }
        }

        /// <summary>
        /// Execute query by printing result on console
        /// </summary>
        /// <param name="resultArray">Resulted string array</param>
        public static void ConsoleQueryExecution(this IEnumerable<string> resultArray)
        {
            foreach (var line in resultArray)
                Console.WriteLine(line);
        }
    }
}
