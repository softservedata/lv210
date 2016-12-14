using System;

namespace Demo2
{
    class Dot : ICloneable
    {
        public double x;
        public double y;

        public Dot()
        {
            x = 0;
            y = 0;
        }
        public Dot(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        //
        public string Show()
        {
            return "(" + x + ", " + y + ")";
        }
      
        public object Clone()
        {
            var dotClone = new Dot();
            dotClone.x = x;
            dotClone.y = y;

            return dotClone;
        }
    }
}
