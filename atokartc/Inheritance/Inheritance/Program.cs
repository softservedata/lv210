using System.Collections.Generic;

namespace Inheritance
{
    public class Program
    {
        public static void Main()
        {
            List<Shape> shapes = new List<Shape>();

            ManipulationWithShapes s = new ManipulationWithShapes();

            shapes = s.GetSpecificShapes(1);
            s.Print(shapes);

            Shape biggestShape = s.FindMaxShape(shapes);

            shapes.Sort();
            s.Print(shapes);
        }
    }
}


