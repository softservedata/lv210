using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    abstract class Shape : IComparable<Shape>
    {
        // Field

        private string _name;

        // Properties

        public double Perimeter { get; set; }

        public double Area { get; set; }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Constructor

        public Shape(string name)
        {
            Name = name;
        }

        // Methods

        public abstract double GetArea();

        public abstract double GetPerimeter();

        /// <summary>
        /// Formating shape output
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format($"{Name} P = {Perimeter:F} S = {Area:F}");
        }

        /// <summary>
        /// Return shape with largest perimeter from shapes collection 
        /// </summary>
        /// <param name="shapes">Shapes collection</param>
        /// <returns></returns>
        public static Shape GetShapeWithLargestPerimeter(IList<Shape> shapes)
        {
            Shape shapeWithLargestPerimeter = shapes[0];

            foreach (var shape in shapes)
            {
                if (shape.Perimeter > shapeWithLargestPerimeter.Perimeter)
                {
                    shapeWithLargestPerimeter = shape;
                }
            }
            return shapeWithLargestPerimeter;
        }

        /// <summary>
        /// For sorting shapes by area value 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Shape other)
        {
            return Area.CompareTo(other.Area);
        }

        /// <summary>
        /// Output shapes collection on console
        /// </summary>
        /// <param name="shapes">Shapes collection</param>
        public static void ConsoleDisplay(List<Shape> shapes )
        {
            foreach (var shape in shapes)
                Console.WriteLine(shape);
        }
    }
}
