using System;

namespace HwEightLinq
{
    /// <summary>
    /// Base class Shape
    /// </summary>
    public abstract class Shape //: IComparable<Shape>
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            }
        }

        public Shape(string name)
        {
            this.name = name;
        }

        public abstract double Area();
        public abstract double Perimeter();
        /// <summary>
        /// Complares area of two shapes
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        public int CompareTo(Shape shape)
        {
            return this.Area().CompareTo(shape.Area());
        }
    }
}
