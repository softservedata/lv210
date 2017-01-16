using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8
{
    public class ConsoleOperations
    {
        public static void PrintShapes(List<Shape> shapes)
        {
            shapes.ForEach(Console.WriteLine);
        }
    }
}
