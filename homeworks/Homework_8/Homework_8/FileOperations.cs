using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8
{
    public class FileOperations
    {
        public static void WriteShapesListToFile(string pathToFile, List<Shape> list)
        {
            File.WriteAllLines(pathToFile, list.Select(item => item.ToString()));
        }
    }
}
