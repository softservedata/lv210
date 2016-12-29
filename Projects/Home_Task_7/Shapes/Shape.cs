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

        // Prop
        public double Perimeter { get; set; }

        public double Area { get; set; }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Shape(string name)
        {
            Name = name;
        }

        // Methods

        public abstract double GetArea();

        public abstract double GetPerimeter();

        public override string ToString()
        {
            return String.Format($"{Name} P = {Perimeter:F} S = {Area:F}");
        }

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

        public int CompareTo(Shape other)
        {
            return Area.CompareTo(other.Area);
        }
    }
}
