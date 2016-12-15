using System;

namespace ComplexTaskAboutShape
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Choose type of shape: \nTriangle - 1 \nSquare - 2\nPlease enter number : ");
            int typeOfShape = int.Parse(Console.ReadLine());

            IShapeFactory factory;
            IShape shape;

            try
            {
                switch (typeOfShape)
                {
                    case 1:
                        factory = new TriangleFactory();
                        shape = factory.CreateShape();
                        InfoAboutShape(shape);
                        break;
                    case 2:
                        factory = new SquareFactory();
                        shape = factory.CreateShape();
                        InfoAboutShape(shape);
                        break;
                }
            }

            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

            Console.ReadKey(); 
        }

        /// <summary>
        /// InfoAboutShape() outputs information about shape
        /// </summary>
        /// <param name="shape"></param>
        private static void InfoAboutShape(IShape shape)
        {
            Console.WriteLine(shape);
            Console.WriteLine("\nShape perimetr is : {0}", shape.GetPerimetr());
            Console.WriteLine("Shape area is : {0}", shape.GetArea());
        }
    }
}
