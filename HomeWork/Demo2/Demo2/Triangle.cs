using System;
using System.Threading;

namespace Demo2
{
   enum TriangleType { Scalene = 0, Isosceles = 2, Equilateral = 3}
   public class Triangle
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
            dot1 = GetRandomDot(100);
            dot2 = GetRandomDot(100);
            dot3 = GetRandomDot(100);
        }
        public Triangle(Dot[] dots)
        {
            this.dot1 = (Dot)dots[0].Clone();
            this.dot2 = (Dot)dots[1].Clone();
            this.dot3 = (Dot)dots[2].Clone();
        }
        public Triangle(Dot dot1, Dot dot2, Dot dot3)
        {
            this.dot1 = (Dot)dot1.Clone();
            this.dot2 = (Dot)dot2.Clone();
            this.dot3 = (Dot)dot3.Clone();
        }
        public bool DoesContainDot(Dot dot)
        {
            double a = (dot1.x - dot.x) * (dot2.y - dot1.y) - (dot2.x - dot1.x) * (dot1.y - dot.y);
            double b = (dot2.x - dot.x) * (dot3.y - dot2.y) - (dot3.x - dot2.x) * (dot2.y - dot.y);
            double c = (dot3.x - dot.x) * (dot1.y - dot3.y) - (dot1.x - dot3.x) * (dot3.y - dot.y);
            if (((a >= 0) && (b >= 0) && (c >= 0)) || ((a <= 0) && (b <= 0) && (c <= 0)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public double Perimeter()
        {
            if (IsValid())
            {
                return SideLength(dot1, dot2) + SideLength(dot1, dot3) + SideLength(dot2, dot3);
            }
            else
            {
                return 0;
            }
        }
        public double Square()
        {
            if (IsValid())
            {
                double p = Perimeter() / 2;
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
        private Dot GetRandomDot(int Max)
        {
            Random random = new Random();
            Dot dot = new Dot(random.Next(Max), random.Next(Max));
            Thread.Sleep(20);
            return dot;
        }
        public void GetInfo()
        {
            Console.WriteLine("---Triangle---");

            if (IsValid())
            {
                InitializeInformation();
                WriteInfo();
            }
            else
            {
                Console.WriteLine("This triangle cannot exist. \nChange the parameters and try again.");
            }
        }
        public bool IsValid()
        {
            if ((dot3.x - dot1.x) / (dot2.x - dot1.x) == (dot3.y - dot1.y) / (dot2.y - dot1.y))
            {
                return false;
            }
            else 
            {
                return true;
            }
        }
        private void InitializeInformation()
        {
            side1 = SideLength(dot1, dot2);
            side2 = SideLength(dot1, dot3);
            side3 = SideLength(dot2, dot3);
            type = TypeOfTriangle();
        }
        private TriangleType TypeOfTriangle()
        {
            return (TriangleType)NumberOfEqualSides();
        }
        private int NumberOfEqualSides()
        {
            if((side1 == side2) && (side2 == side3))
            {
                return 3;
            }
            else if((side1 == side2) || (side1 == side3) || (side2 == side3))
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
        private double SideLength(Dot dot1, Dot dot2)
        {
            return Math.Sqrt(Math.Pow((dot2.x - dot1.x), 2) + Math.Pow((dot2.y - dot1.y), 2));
        }
        private string CreateInfo()
        {
            string MainInfo = string.Format("Type of the triangle is: {0} \nDot A: {1} \nDot B: {2} \nDot C: {3} \nPerimeter is: {4}" +
                "\nSquare is: {5} \nFirst side is: {6} \nSecond side is: {7} \nThird side is: {8}", 
                type, dot1.Show(), dot2.Show(), dot3.Show(), Perimeter(), Square(), side1, side2, side3);
            return MainInfo;
        }
        private void WriteInfo()
        {
            Console.WriteLine(CreateInfo());
        }
    
    }
}
