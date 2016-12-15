using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    class Program
    {
        static void Main(string[] args)
        {
            //Triangle t = new Triangle(new Point(5, 0), new Point(0, 6), new Point(5, 1));
            //Console.WriteLine(t);
            //Console.WriteLine("perim=" + t.GetPerimetr());
            //Console.WriteLine("area=" + t.GetArea());

            //RightAngled r = new RightAngled(3, 3);
            //Triangle tr = new RightAngled(3, 3);
            //Console.WriteLine(r);
            //Console.WriteLine("area=" + r.GetArea());
            //Console.WriteLine("area=" + tr.GetArea());

            //Isosceles i = new Isosceles(8, 9);
            //Triangle ti = new Isosceles(7, 9);
            //Console.WriteLine(i);
            //Console.WriteLine("area=" + i.GetArea());
            //Console.WriteLine("area=" + ti.GetArea());

            //RightAngled rrr = new RightAngled();

            //IsoscelesRightAngle ira = new IsoscelesRightAngle(3);
            //Console.WriteLine(ira);
            //Console.WriteLine("area Right = " + r.GetArea());
            //Console.WriteLine("area Heron =" + tr.GetArea());
            //Console.WriteLine("area H =" + ira.GetArea());

            //Equilateral equi = new Equilateral(3);
            //Triangle teq = new Triangle(3,3,3);
            //Console.WriteLine(equi);
            ////Console.WriteLine("area Right = " + r.GetArea());
            //Console.WriteLine("area Heron =" + teq.GetArea());
            //Console.WriteLine("area equi =" + equi.GetArea());

            Console.WriteLine("------------------------");
            Triangle t1 = new Triangle(13, 13, 18.38);
            Console.WriteLine(t1);
            Console.WriteLine("--------------");
            Console.WriteLine("area: " + t1.GetArea());

            IsoscelesRightAngle r = new IsoscelesRightAngle(13);
            Console.WriteLine(r);

            Console.WriteLine("--------------");
 
 


            // 6-9
            // 4 -3 
        }
}
}
