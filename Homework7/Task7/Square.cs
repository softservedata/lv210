using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    class Square : Shape
    {
       private int side;
      public int Side
        {
            get { return side; }
            set { side = value; }
        }
      public Square(string name, int side) : base(name)
      {
          this.Side = side; 
      }
      public override double Area()
      {
          return this.Side*this.Side;
      }
      public override double Perimeter()
      {
          return 4 * this.Side;
      }
    }
}
