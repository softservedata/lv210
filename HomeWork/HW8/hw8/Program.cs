using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw8
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape> { };
            Console.WriteLine("Enter data for 6 Shapes");

            for (int i = 0; i < 3; i++)
            {
                Console.Write("\nEnter radius for circle: ");
                shapes.Add(new Circle(double.Parse(Console.ReadLine())));
                Console.Write("\nEnter side for square: ");
                shapes.Add(new Square(double.Parse(Console.ReadLine())));
            }
            Console.WriteLine("----------");

            Functions.FindByNameAndWriteToFile(shapes);
            Functions.WriteToFileWithAppropriateRange(shapes);

            Functions.RemoveShapesWithPerimeterLessThanValue(ref shapes, 5);
            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.ToString());
            }

            ///////////////////
            var data = FileOperations.ReadDataFromFile("data.txt");
            FileOperations operations = new FileOperations();
            operations.CountOfString(data);
            operations.FindLongestLine(data);
            operations.FindShortestLine(data);
            operations.SearchStringWithAppropriateSubstring(data, "var");

            Console.ReadKey();
        }
    }
}
