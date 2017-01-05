using System;

namespace HW7
{
    abstract class Shape : IComparable
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public Shape(string name)
        {
            this.name = name;
        }

        abstract public double Area();

        abstract public double Perimeter();
        
        private const double  precision = 0.0001;

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            var shape = obj as Shape;

            if (shape != null)
            {
                return Area().CompareTo(shape.Area());
            }
            else
            {
                throw new ArgumentException("Object should be shape");
            }
        }


        public static bool operator <(Shape firstShape, Shape secondShape)
        {
            return (firstShape.Area() < secondShape.Area());
        }

        public static bool operator >(Shape firstShape, Shape secondShape)
        {
            return (firstShape.Area() > secondShape.Area());
        }

        public static bool operator <=(Shape firstShape, Shape secondShape)
        {
            return (firstShape.Area() <= secondShape.Area());
        }

        public static bool operator >=(Shape firstShape, Shape secondShape)
        {
            return (firstShape.Area() >= secondShape.Area());
        }

        public override string ToString()
        {
            return $"\nShape: {Name}.\nArea = {Area()}.\nPerimeter = {Perimeter()}.";
        }
    }
}
