using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape> { };
            Console.WriteLine("Enter data for 10 Shapes");

            for(int i = 0; i < 5; i++)
            {
                Console.Write("\nEnter radius for circle: ");
                shapes.Add(new Circle(double.Parse(Console.ReadLine())));
                Console.Write("\nEnter side for square: ");
                shapes.Add(new Square(double.Parse(Console.ReadLine())));
            }

            Console.WriteLine("----------");

            for(int i = 0; i < shapes.Count; i++)
            {
                Console.WriteLine("The area of a {0} is {1}", shapes[i].name, shapes[i].Area());
                Console.WriteLine("The perimeter of a {0} is {1}", shapes[i].name, shapes[i].Perimeter());
            }

            Console.WriteLine("----------");
            Console.WriteLine("Largest perimeter has {0} with index {1} and perimeter {2}",
                shapes[Functions.LargestPerimeter(shapes)].name, Functions.LargestPerimeter(shapes),
                shapes[Functions.LargestPerimeter(shapes)].Perimeter());

            Console.WriteLine("----------");
            Console.WriteLine("Sorted list of shapes: ");
            shapes.Sort();

            for(int i = 0; i < shapes.Count; i++)
            {
                Console.WriteLine("{0} {1}", shapes[i].name, shapes[i].Area());
            }

            Console.ReadKey();
        }
    }
}
