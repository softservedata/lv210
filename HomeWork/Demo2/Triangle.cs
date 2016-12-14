using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2
{
    enum TriangleType { Scalene, Isosceles, Equilateral}
    class Triangle
    {
        private Dot dot1;
        private Dot dot2;
        private Dot dot3;
        private TriangleType type;
        private double side1;
        private double side2;
        private double side3;

        public Triangle()
        {
            dot1 = new Dot();
            dot2 = new Dot();
            dot3 = new Dot();
        }
        public Triangle(Dot dot1, Dot dot2, Dot dot3)
        {
            this.dot1 = (Dot)dot1.Clone();
            this.dot2 = (Dot)dot2.Clone();
            this.dot3 = (Dot)dot3.Clone();
        }
        //
        public bool DoesContainDot(Dot dot)
        {
            return false;
        }
        public double Perimetr()
        {
            if (IsValid())
                return SideLength(dot1, dot2) + SideLength(dot1, dot3) + SideLength(dot2, dot3);
            else
                return 0;
        }
        public double Square()
        {
            if (IsValid())
            {
                double p = Perimetr() / 2;
                double firstSide = SideLength(dot1, dot2);
                double secondSide = SideLength(dot1, dot3);
                double thirdSide = SideLength(dot2, dot3);
                return Math.Sqrt(p * (p - firstSide) * (p - secondSide) * (p - thirdSide));
            }
            else
            {
                return 0;
            }
        }
        public void GetInfo()
        {
            Console.WriteLine("---Triangle---");

            if (IsValid())
            {
                SetInfo();
                WriteInfo();
            }
            else
            {
                Console.WriteLine("This triangle cannot exist. \nChange the parameters and try again.");
            }
        }
        private bool IsValid()
        {
            return true;
        }
        private void SetInfo()
        {
            type = getType();
            side1 = SideLength(dot1, dot2);
            side2 = SideLength(dot1, dot3);
            side3 = SideLength(dot2, dot3);
        }
        private TriangleType getType()
        {
            TriangleType d = new TriangleType();
            return d;
        }
        private double SideLength(Dot dot1, Dot dot2)
        {
            return Math.Sqrt(Math.Pow((dot2.x - dot1.x), 2) + Math.Pow((dot2.y - dot1.y), 2));
        }
        private void WriteInfo()
        {
            Console.WriteLine("Type of the triangle is: {0}", type);
            Console.WriteLine("Dot A: {0}", dot1.Show());
            Console.WriteLine("Dot B: {0}", dot2.Show());
            Console.WriteLine("Dot C: {0}", dot3.Show());
            Console.WriteLine("First side is: {0}", side1);
            Console.WriteLine("Second side is: {0}", side2);
            Console.WriteLine("Third side is: {0}", side3);
            Console.WriteLine("Perimeter is: {0}", Perimetr());
            Console.WriteLine("Square is: {0}", Square());
        }
    
    }
}
