using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public abstract class Shape
    {
        public Shape(string name)
        {
            Name = name;
        }

        public double Perimeter { get; protected set; }
        public double Area { get; protected set; }
        public string Name { get; }

        protected abstract double GetArea();
        protected abstract double GetPerimeter();

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
            return (this.Name == other.Name) && 
                (this.Perimeter == other.Perimeter) && 
                (this.Area == other.Area);
        }
    }
}
