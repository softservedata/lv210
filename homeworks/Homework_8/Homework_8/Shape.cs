using System;

namespace Homework_8
{
    public abstract class Shape : IComparable<Shape>
    {
        public string Name { get; set; }

        public Shape(string name)
        {
            this.Name = name;
        }
         
        public abstract double Area();
        public abstract double Perimeter();

        public int CompareTo(Shape other)
        {
            return this.Area().CompareTo(other.Area());
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
           if (obj == null)
            {
                return false;
            }
         
            Shape otherShape = obj as Shape;
            if ((Object)otherShape == null)
            {
                return false;
            }
                        
            return (Name == otherShape.Name) && (Area() == otherShape.Area() && Perimeter() == otherShape.Perimeter());
        }

        public override int GetHashCode()
        {
            return Area().GetHashCode()^Perimeter().GetHashCode();
        }
    }
}
