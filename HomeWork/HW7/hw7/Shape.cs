﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw7
{
   public abstract class Shape : IComparable<Shape>
    {
        public string name;

        public Shape()
        {
            name = "Shape";
        }
        public Shape(string name)
        {
            this.name = name;
        }

        public abstract double Area();
        public abstract double Perimeter();

        public int CompareTo(Shape other)
        {
            return this.Area().CompareTo(other.Area());
        }
    }
}
