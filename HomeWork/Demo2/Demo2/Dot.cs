using System;

namespace Demo2
{
   public class Dot : ICloneable
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
        public string Show()
        {
            return "(" + x + ", " + y + ")";
        }
        public static bool AreDotsEqual(Dot dot1, Dot dot2)
        {
            if ((dot1.x == dot2.x) && (dot1.y == dot2.y))
            {
                return true;
            }
            else
            {
                return false;
            }
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
