using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
      //1) In Main() create list of Shape, then ask user to enter data of 10 different shapes. 
      //Write name, area and perimeter all of shapes.
            List<Shape> shapeList = new List<Shape>();
            string shapeName;
            int shapeFieldForCalcaulation;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Please enter name of shape{0}",i);
                shapeName = Console.ReadLine();

                Console.WriteLine("Please enter radius/side of {0}", shapeName);
                shapeFieldForCalcaulation = Convert.ToInt32(Console.ReadLine());

                if (shapeName.ToLower().Contains("circle"))
                {
                    Circle circle = new Circle(shapeName, shapeFieldForCalcaulation);
                    shapeList.Add(circle);
                    continue;
                } 
                if (shapeName.ToLower().Contains("square"))
                {
                    Square square = new Square(shapeName, shapeFieldForCalcaulation);
                    shapeList.Add(square);
                }
                else 
                {
                    Console.WriteLine("You entered unsupported shape type ({0})!", shapeName);
                    i--;
                }
            }

            foreach (Shape item in shapeList)
            {
                Console.WriteLine(item.Name + " has perim " + item.Perimeter() + " and Area " + item.Area());
            }
            Console.ReadKey();

         //2) Find shape with the largest perimeter and print its name.
            
            double largestPerimeter = shapeList[0].Perimeter();
            string shapeNameWithLargestPerimeter=shapeList[0].Name;
            foreach (var item in shapeList)
            {
                if (largestPerimeter<item.Perimeter())
                {
                    largestPerimeter = item.Perimeter();
                    shapeNameWithLargestPerimeter = item.Name;
                }
            }
            Console.WriteLine("{0} has largest perimeter", shapeNameWithLargestPerimeter);
            Console.ReadKey();
            
            //3) Sort shapes by area and print obtained list (Remember about IComparable)
            shapeList.Sort();
            Console.WriteLine("Sorted Shape List:");
            foreach (Shape item in shapeList)
            {                
                Console.WriteLine(item.Name + " has perim " + item.Perimeter() + " and Area " + item.Area());
            }
            Console.ReadKey();
        }
    }
}
