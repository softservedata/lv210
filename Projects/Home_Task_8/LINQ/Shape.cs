using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public abstract class Shape : IComparable<Shape>
    {
        protected double area;
        protected double perimeter;

        public Shape(string name)
        {
            Name = name;
        }

        public abstract double Perimeter { get; protected set; }
        public abstract double Area { get; protected set; }
        public string Name { get; }

        public int CompareTo(Shape other)
        {
            return Area.CompareTo(other.Area);
        }

        public override bool Equals(object obj)
        {
            // Check if the obj is a Shape.
            var other = obj as Shape;
            if (other == null)
            {
                return false;
            }

            // Condition of equality
            return (this.Name.Equals(other.Name)) &&
                (this.Perimeter.Equals(other.Perimeter)) &&
                (this.Area.Equals(other.Area));
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Area.GetHashCode() ^ this.Perimeter.GetHashCode();
        }
    }
}
