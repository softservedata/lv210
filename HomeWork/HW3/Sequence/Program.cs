using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int temp;
            int count = 0;

            Console.Write("Enter integer positive number: \n-");
            temp = int.Parse(Console.ReadLine());

            while(temp > 0)
            {
                sum += temp;
                count++;
                Console.Write("- ");
                temp = int.Parse(Console.ReadLine());
            }
            if(sum > 0 && count > 0)
            Console.WriteLine("Середнє арифметчне: {0}", sum / count);
            else
                Console.WriteLine("Неправильні дані");
            Console.ReadKey();
        }
    }
}
