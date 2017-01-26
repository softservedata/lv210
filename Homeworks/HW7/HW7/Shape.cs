using System;

namespace HW7
{
    public abstract class Shape : IComparable
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

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            // is
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

        public override string ToString()
        {
            return $"\nShape: {Name}.\nArea = {Area()}.\nPerimeter = {Perimeter()}.";
        }
    }
}
