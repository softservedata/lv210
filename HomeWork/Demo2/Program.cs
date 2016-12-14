using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dot dot1 = new Dot(0, 5.5);
            Dot dot2 = new Dot(15, 5.5);
            Dot dot3 = new Dot(6, 11);
            Triangle tr = new Triangle(dot1, dot2, dot3);
            tr.GetInfo();
            dot1 = dot2;
            tr.GetInfo();
            Console.WriteLine("dot1 {0} \ndot2 {1} \ndot3 {2}", dot1.Show(), dot2.Show(), dot3.Show());

            Console.ReadKey();
        }
    }
}
