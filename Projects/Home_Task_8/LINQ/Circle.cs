﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Circle : Shape
    {
        // Field

        private double _radius;

        // Constructor

        public Circle(string name, double radius) : base(name)
        {
            _radius = radius;
            Perimeter = GetPerimeter();
            Area = GetArea();
        }

        // Methods

        public override double GetArea()
        {
            return Math.PI * _radius * _radius;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * _radius;
        }
    }
}