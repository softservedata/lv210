using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes;

namespace LINQ
{
    public static class ShapesUtilityClass
    {
        public static List<Shape> GetShapesCollection()
        {
            List<Shape> shapes = new List<Shape>()
            {
                new Circle("Circle-1 (r = 0.5 cm)", 0.5),
                new Circle("Circle-2 (r = 3 cm)", 3),
                new Circle("Circle-3 (r = 6 cm)", 6),
                new Square("Square-1 (leg = 9 cm)", 9),
                new Square("Square-2 (leg = 12 cm)", 12),
                new Square("Square-3 (leg = 15 cm)", 15)
            };

            return shapes;
        }

        public static void WriteToFile(this IEnumerable<Shape> shapes, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                foreach (var shape in shapes)
                {
                    writer.WriteLine(shape.ToString());
                }
                writer.WriteLine($"Mod: {DateTime.Now} {Environment.NewLine}");
            }
        }

        public static string GetPath(string fileName)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
        }
    }
}
