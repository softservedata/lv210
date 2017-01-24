﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw8
{
    public class Circle : Shape
    {
        private const double Pi = 3.14159;
        private double radius;
       
        public Circle(double radius) : base("Circle")
        {
            this.radius = radius;
        }

        public override double Area()
        {
            return Pi * radius * radius;
        }
        public override double Perimeter()
        {
            return 2 * Pi * radius;
        }
    }
}