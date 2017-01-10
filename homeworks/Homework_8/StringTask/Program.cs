using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace StringTask
{
    internal class Program
    {
        public static Dictionary<int, int> SymbolsPerLine(string[] input)
        {
            var symbolsPerLine = new Dictionary<int, int>();
            var i = 0;
            foreach (var line in input)
            {
                symbolsPerLine.Add(i, line.Length);
                i++;
            }
            return symbolsPerLine;
        }


        public static List<string> LongestStrings(string[] input)
        {
            var maxString = input.Max(line => line.Length);
            return input.Where(item => item.Length == maxString).ToList();
        }

        public static List<string> ShortestStrings(string[] input)
        {
            var minString = input.Min(line => line.Length);
            return input.Where(item => item.Length == minString).ToList();
        }

        public static List<string> StringsContainsWord(string[] input, string word)
        {
            return input.Where(item => item.Contains(word)).ToList();
        }

        private static void Main(string[] args)
        {
            var text = File.ReadAllLines("FileToRead.txt");
            var symbolsPerLine = SymbolsPerLine(text);
            var symbolsCountPerLine = symbolsPerLine.Select(line => line.Key + "=>" + line.Value);
            foreach (var keyValue in symbolsPerLine)
                Console.WriteLine("String {0}: {1}", keyValue.Key, keyValue.Value);

            var longestLines = LongestStrings(text);
            longestLines.ForEach(Console.WriteLine);

            var shortestLines = ShortestStrings(text);
            longestLines.ForEach(Console.WriteLine);

            Console.WriteLine("Lines with word 'var'");
            var linesWithVar = StringsContainsWord(text, "var");

            linesWithVar.ForEach(Console.WriteLine);
            Console.ReadKey();
        }
    }
}
