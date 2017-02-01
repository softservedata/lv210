﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTask
{
    /// <summary>
    /// B) Create Console Application project.
    /// Prepare txt file with a lot of text inside (for example take you.cs file from previos homework)
    /// Read all lines of text from file into array of strings.
    /// Each array item contains one line from file.
    /// Complete next tasks:
    /// 1) Count and write the number of symbols in every line.
    /// 2) Find the longest and the shortest line.
    /// 3) Find and write only lines, which consist of word "var"
    /// </summary>
    internal class Program
    {
        public const string FILE = "FileToRead.txt";

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


        public static List<string> GetLongestString(string[] input)
        {
            var maxString = input.Max(line => line.Length);
            return input.Where(item => item.Length == maxString).ToList();
        }

        public static List<string> GetShortestString(string[] input)
        {
            var minString = input.Min(line => line.Length);
            return input.Where(item => item.Length == minString).ToList();
        }

        public static List<string> GetStringsContainsWord(string[] input, string word)
        {
            return input.Where(item => item.Contains(word)).ToList();
        }

        private static void Main(string[] args)
        {
            var text = File.ReadAllLines(FILE);
            var symbolsPerLine = SymbolsPerLine(text);
            var symbolsCountPerLine = symbolsPerLine.Select(line => line.Key + "=>" + line.Value);
            foreach (var keyValue in symbolsPerLine)
                Console.WriteLine("String {0}: {1}", keyValue.Key, keyValue.Value);

            var longestLines = GetLongestString(text);
            longestLines.ForEach(Console.WriteLine);

            var shortestLines = GetShortestString(text);
            longestLines.ForEach(Console.WriteLine);

            Console.WriteLine("Lines with word 'var'");
            var linesWithVar = GetStringsContainsWord(text, "var");

            linesWithVar.ForEach(Console.WriteLine);
            Console.ReadKey();
        }
    }
    }