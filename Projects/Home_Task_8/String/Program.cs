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
                //string fileNameToRead = "shape.cs";
                string fileNameToRead = "stringTestData.txt";
                string[] textContent = File.ReadAllLines(StringUtilityClass.GetFilePathFromDesktop(fileNameToRead));

                // Write the number of symbols in each line

                string fileNameToWrite = "strings.txt";
                textContent.GetEachLineLengthInfo().WriteToFile(fileNameToWrite, title: "Lines Length");

                // Longest, shortest lines and lines with substring "var"

                textContent.GetLongestLines()
                    .WriteToFile(fileNameToWrite, title:"Longest lines");

                textContent.GetShortestLines()
                    .WriteToFile(fileNameToWrite, title: "Shortest lines");

                textContent.GetLinesContainsSubstring("hello")
                    .WriteToFile(fileNameToWrite, title: "Lines with substring 'var'");
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
