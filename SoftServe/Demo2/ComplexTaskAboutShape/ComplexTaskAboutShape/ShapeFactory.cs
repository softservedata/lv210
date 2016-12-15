using System;

namespace ComplexTaskAboutShape
{
    /// <summary>
    /// Class ShapeFactory implements interface IShapeFactory.
    /// Classes which inherits from ShapeFactory should implements method CreateShape().
    /// Method GetCoordinate() returns point(s) for our shape.
    /// </summary>
    
    abstract class ShapeFactory : IShapeFactory
    {
        public abstract IShape CreateShape();

        protected Point GetCoordinate()
        {
            double x, y;

            Console.Write("Input coordinate x : ");
            while (!double.TryParse(Console.ReadLine(), out x))
            {
                Console.Write("The value shouldn't contains characters, please try again : ");
            }

            Console.Write("Input coordinate y : ");
            while (!double.TryParse(Console.ReadLine(), out y))
            {
                Console.Write("The value shouldn't contains characters, please try again : ");
            }

            return new Point(x, y);
        }
    }
}
