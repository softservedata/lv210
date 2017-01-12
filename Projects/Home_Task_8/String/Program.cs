using System;
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
                // --- Data Source --- //

                string fileName = "shape.cs";
                string[] textContent = File.ReadAllLines(StringUtilityClass.GetFileFromDesktop(fileName));

                // --- Write the number of symbols in each line --- //

                textContent.ConsoleDisplaySymbolsInEachLine();

                // --- Queries --- //

                var longestLine = textContent.Where(line => line.Length ==
                                                          textContent.Max(item => item.Length));

                var shortestLine = textContent.Where(line => line.Length ==
                                                          textContent.Min(item => item.Length));

                var consistWordVarLines = textContent.Where(item => item.ToLower().Contains("var"));

                // --- Queries Execution --- //

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
}
