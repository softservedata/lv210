using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ShapesProject
{
    
    public class ShapesCreator
    {
        public static void Print(IEnumerable data)
        {
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
        }

        public static Shape FindMaxShapeByPerimeter(List<Shape> shapeList)
        {
            Shape maximalShape = shapeList[0];

            maximalShape = shapeList.Where(item => item.Perimeter() > maximalShape.Perimeter()).First<Shape>();
            return maximalShape;
        }

        public static void Main()
        {
            List<Shape> shapes = new List<Shape>();
            shapes.Add(new Circle("circle1",0.01));
            shapes.Add(new Circle("circle2",2.5));
            shapes.Add(new Square("square",0.2));
            shapes.Add(new Square("square2", 1.0));
            Print(shapes);
            
            Shape maximalShape = FindMaxShapeByPerimeter(shapes);
            Console.WriteLine("Shape with max  perimeter [{0}]",maximalShape);
            
            Console.WriteLine("Shapes sorted by area");
            shapes.Sort();
            Print(shapes);
            
            Console.ReadKey();
        }
    }
}
