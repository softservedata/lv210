using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_Task1
{
    class Program
    {
        ///<summary>
        /// Task Description : read 3 float numbers and check: are they all belong to the range [-5,5].
        ///</summary>

        static void Main(string[] args)
        {
            Console.Write("Input 1st number: ");
            float f1 = float.Parse(Console.ReadLine());

            Console.Write("Input 2nd number: ");
            float f2 = float.Parse(Console.ReadLine());

            Console.Write("Input 3d number: ");
            float f3 = float.Parse(Console.ReadLine());

            Console.WriteLine("Are all values belong to range [-5,5]? - {0}", IsBelongToRange(f1,f2,f3));

            Console.ReadKey();
        }

        private static bool IsBelongToRange(params float[] list)
        {
            bool belongToRange = false;
            foreach (var item in list)
            {
                if (item <= 5 && item >= -5)
                    belongToRange = true;
                else
                    belongToRange = false;
            }

            return belongToRange;
        }
    }
}
