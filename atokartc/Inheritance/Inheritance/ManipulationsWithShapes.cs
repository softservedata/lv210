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

        private int EnterPositiveInt()
        {
            int readedVar = -1;
            bool isIntEntered = Int32.TryParse(Console.ReadLine(), out readedVar);

            if (isIntEntered == false || readedVar <= 0)
            {
                Console.WriteLine("Please, enter an positive integer");
                return this.EnterPositiveInt();
            }
            return readedVar;
        }

        private int GetRadiusFromConsole()
        {
            Console.WriteLine("Please, enter radius value!");
            return this.EnterPositiveInt();
        }

        private int GetSideFromConsole()
        {
            Console.WriteLine("Please, enter side value!");
            return this.EnterPositiveInt();
        }

        private int EnterNumToSelectShape()
        {
            Console.WriteLine("Please, enter an integer: 1 - to select Circle, 2 -to select Square");
            int enteredValue = EnterPositiveInt();

            if (enteredValue != 1 || enteredValue != 2)
            {
                return enteredValue;
            }
            else
            {
                Console.WriteLine("You entered incorrect value!");
                return EnterPositiveInt();
            }
        }

        /// <summary>
        ///Returns specific number of shapes added manually.
        /// </summary>
        /// <param name="shapesCounter"></param>
        /// <returns></returns>
        public List<Shape> GetSpecificShapes(int shapesCounter)
        {
            List<Shape> list = new List<Shape>();
            Shape shape = null;

            for (int i = 0; i < shapesCounter; i++)
            {
                shape = GetSpecificShape();
                list.Add(shape);
            }
            return list;
        }

        public Shape GetSpecificShape()
        {
            Shape shape = null;
            int shapeNum = EnterNumToSelectShape();

            switch (shapeNum)
            {
                case 1:
                    int radius = GetRadiusFromConsole();
                    shape = new Circle(circleName, radius);
                    break;
                case 2:
                    int side = GetSideFromConsole();
                    shape = new Square(squareName, side);
                    break;
            }
            return shape;
        }

        public Shape FindMaxPerimeter(List<Shape> shapeList)
        {
            Shape maximalShape = shapeList[0];

            foreach (Shape item in shapeList)
            {
                if (item.Perimeter() > maximalShape.Perimeter())
                {
                    maximalShape = item;
                }
            }
            return maximalShape;
        }

        public void Print(IEnumerable data)
        {
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
