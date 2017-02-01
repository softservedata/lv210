﻿using System;

namespace HomeWorkSeven
{
    /// <summary>
    /// Base class Shape
    /// </summary>
    public abstract class Shape
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                this.name = value;
            }
        }

        public Shape(string name)
        {
            this.Name = name;
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