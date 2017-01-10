using System;
using System.Collections;
using System.Collections.Generic;

namespace Inheritance
{
    /// <summary>
    /// Class reperesents methods that are used to make operations with shapes.
    /// </summary>
    public class ManipulationWithShapes
    {
        private string circleName = "Circle";
        private string squareName = "Square";
        /// <summary>
        ///Returns specific number of shapes added manually.
        /// </summary>
        /// <param name="shapesCounter"></param>
        /// <returns></returns>
        public List<Shape> GetSpecificShapes(int shapesCounter)
        {
            List<Shape> list = new List<Shape>();
            Shape shape = null;

            Console.WriteLine("Select shapes that will be added to the following list: press 1 to add Circle to list,"
                + " press 2 if you want to add Square to list");

            for (int i = 0; i < shapesCounter; i++)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        int radius = Int32.Parse(Console.ReadLine());
                        shape = new Circle(circleName + i, radius);
                        break;
                    case "2":
                        int side = Int32.Parse(Console.ReadLine());
                        shape = new Square(squareName + i, side);
                        break;
                }
                list.Add(shape);
            }
            return list;
        }

        public void Print(IEnumerable data)
        {
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        public Shape FindMaxShape(List<Shape> shapeList)
        {
            Shape maximalShape = shapeList[0];

            foreach (Shape item in shapeList)
            {
                if (item.Perimeter() > maximalShape.Perimeter()) maximalShape = item;
            }

            return maximalShape;
        }
    }
}
