using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{

    class Circle : Shape
    {
        private int radius;
        public int Radius { get; set; }
        public Circle(string name, int radius) : base(name)
      {
          this.Radius = radius; 
      }
        public override double Area() 
        {
            return Math.PI * this.Radius * this.Radius;
        }
        public override double Perimeter() 
        {
            return 2 * Math.PI * this.Radius;
        }
    }
}
