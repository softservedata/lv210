using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSecondHomework

{
    using Function;
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (exit == false)
            {
                Console.WriteLine("Select action:");
                Console.WriteLine(" ");
                Console.WriteLine("Verify if numbers are from range - press 1");
                Console.WriteLine("Find min and max value - press 2");
                Console.WriteLine("Find error name - press 3");
                Console.WriteLine("Information about dog - press 4:");
                string key = Console.ReadLine();
                Console.WriteLine(" ");

                int choise;
                try
                {
                    choise = Convert.ToInt32(key);
                }
                catch(Exception)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Incorrect data! Try again?");
                    Console.WriteLine("Yes - press 'Y', No - press 'N'");
                    string ss = Console.ReadLine();
                    if (ss == "Y") exit = false; else exit = true;
                    continue;
                }

                switch(choise)
                {
                    case 1:
                        {
                            Function.CheckNumbers();
                            break;
                        }
                    case 2:
                        {
                            Function.FindMinMax();
                            break;
                        }
                    case 3:
                        {
                            Function.GetErrorName();
                            break;
                        }
                    case 4:
                        {
                            Function.GetInformationAboutDog();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("Incorrect data!");
                            break;
                        }
                }

                Console.WriteLine(" ");
                Console.WriteLine("Once more?");
                Console.WriteLine("Yes - press 'Y', No - press 'N'");
                string s = Console.ReadLine();
                if (s == "Y") exit = false; else exit = true;


            }
        }
    }
}
