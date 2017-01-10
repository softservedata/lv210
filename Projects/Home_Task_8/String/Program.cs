﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String
{
    /// <summary>
    /// Read all lines of text from file into array of strings.
    /// Each array item contains one line from file.
    /// Complete next tasks:
    /// 1) Count and write the number of symbols in every line.
    /// 2) Find the longest and the shortest line.
    /// 3) Find and write only lines, which consist of word "var"
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // --- Data Source ---

                string fileName = "shape.cs";
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                string[] textContent = File.ReadAllLines(path);

                // --- Write the number of symbols in every line ---

                textContent.DisplaySymbolsInEachLine();

                // --- Queries ---

                var longestLine = textContent.Where(line => line.Length ==
                                                          textContent.Max(i => i.Length));

                var shortestLine = textContent.Where(line => line.Length ==
                                                          textContent.Min(i => i.Length));

                var consistWordVarLines = textContent.Where(i => i.ToLower().Contains("var"));

                // --- Queries Execution ---

                longestLine.ConsoleQueryExecution();
                shortestLine.ConsoleQueryExecution();
                consistWordVarLines.ConsoleQueryExecution();

            }

            catch (FileNotFoundException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }

    static class StringUtilityClass
    {
        /// <summary>
        /// Output on console the number of symbols in every line from string array
        /// </summary>
        /// <param name="textContent">String array with text</param>
        public static void DisplaySymbolsInEachLine(this string[] textContent)
        {
            int lineNumber = 1;

            foreach (var line in textContent)
            {
                Console.WriteLine($"Line №{lineNumber} has {line.Length} symbols.");
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