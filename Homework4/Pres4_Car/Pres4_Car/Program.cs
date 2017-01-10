using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pres4_Car
{
    class Program
    {
        static void Main(string[] args)
        {
            Car[] Cars = new Car[3];
            for (int i = 0; i < 3; i++)
            {
                Cars[i] = new Car();
                Cars[i].Input();
            }
            Console.Write("Enter percent of price increase ");
            int priceIncrease=Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < 3; i++)
            {
                Cars[i].ChangePrice(priceIncrease);
                Cars[i].Print();
            }
            Console.Write("Enter desired color ");
            string desiredColor = Console.ReadLine();
            for (int i = 0; i < 3; i++)
            {
                if (Cars[i].Color == "White")
                {
                    Cars[i].Color = desiredColor;
                }
                Cars[i].Print();
            }
            Console.ReadKey();
        }
    }
}
