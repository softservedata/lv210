using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQAndFilesWithShapes
{
    class ShapeFromConsole
    {
        enum ShapeType
        {
            Circle = 1,
            Square
        }

        public List<Shape> GetListOfShapes()
        {
            List<Shape> shapes = new List<Shape>();

            Console.Write("Input amount of shapes : ");
            var amountOfShapes = int.Parse(Console.ReadLine());

            for (int i = 0; i < amountOfShapes; i++)
            {
                Console.WriteLine("Input type of shape \nCircle - 1 \nSquare - 2");
                var shapeType = int.Parse(Console.ReadLine());

                shapes.Add(DefineShapeType((ShapeType)shapeType));
            }

            return shapes;
        }

        /// <summary>
        /// Defines shape type - circle or square
        /// </summary>
        /// <param name="shapeType">Input type of shape</param>
        /// <returns></returns>
        private Shape DefineShapeType(ShapeType shapeType)
        {
            Shape shape = null;
            string shapeName = string.Empty;
            double sideLength = 0.0;

            switch ((int)shapeType)
            {
                case 1:
                    GetCorrectValuesForShape(out shapeName, out sideLength);
                    shape = new Circle(shapeName, sideLength);
                    break;
                case 2:
                    GetCorrectValuesForShape(out shapeName, out sideLength);
                    shape = new Square(shapeName, sideLength);
                    break;
            }

            return shape;
        }

        /// <summary>
        /// Returns name of Shape with largest perimetr.
        /// </summary>
        /// <param name="shapes">Input list of shapes</param>
        private static string GetShapeNameWithLargestPerimetr(List<Shape> shapes)
        {
            var largestPerimetr = 0.0;
            string shapeName = string.Empty;

            foreach (var item in shapes)
            {
                if (item.GetPerimetr() >= largestPerimetr)
                {
                    largestPerimetr = item.GetPerimetr();
                    shapeName = item.Name;
                }
            }

            return shapeName;
        }

        private void GetCorrectValuesForShape(out string shapeName, out double sideLength)
        {
            string[] inputShapes;

            Console.WriteLine("Input data about circle : name and radius(divided by space)");
            inputShapes = Console.ReadLine().Split(' ');

            while (double.Parse(inputShapes[1]) <= 0)
            {
                Console.WriteLine("Incorrect data (length should be bigger than 0). Please try again : ");
                inputShapes = Console.ReadLine().Split(' ');
            }

            shapeName = inputShapes[0];
            sideLength = double.Parse(inputShapes[1]);
        }
    }
}
