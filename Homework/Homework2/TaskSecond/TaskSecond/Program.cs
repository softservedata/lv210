using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSecond
{
    using AppFunctions;
    class Program
    {
        static void Main(string[] args)
        {
            #region GoThroughtTasks

            bool exit = false;

            while (exit==false)
            {

                Console.WriteLine("Select task:");
                Console.WriteLine("Parity of numbers - press 1");
                Console.WriteLine("Actions with radius - press -2");
                Console.WriteLine("Day time - press 3");
                Console.WriteLine("Favourite color - press 4");
                Console.WriteLine("Today's date - press 5");
                int choise = 0;

                try
                {
                    choise = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Incorrect data! Try again?");
                    Console.WriteLine("Yes - press 'Y', No - press 'N'");
                    string s = Console.ReadLine();
                    if (s == "Y") exit = false; else exit = true;
                    Console.WriteLine("");
                    continue;

                }
                Console.WriteLine();

                switch (choise)
                {
                    case 1:
                        {
                            #region Parity
                            Console.WriteLine("T A S K 1");
                            Console.WriteLine();
                            int res = AppFunctions.ParityTest();
                            #endregion
                            break;
                        }
                    case 2:
                        {
                            #region Radius
                            Console.WriteLine("T A S K 2");
                            Console.WriteLine();
                            int res = AppFunctions.RadiusActions();
                            #endregion
                            break;
                        }
                    case 3:
                        {
                            #region Greeting
                            Console.WriteLine("T A S K 3");
                            Console.WriteLine();
                            int res = AppFunctions.Greeting();
                            #endregion
                            break;
                        }
                    case 4:
                        {
                            #region Color
                            Console.WriteLine("T A S K 4");
                            Console.WriteLine();
                            AppFunctions.FavouriteColor();
                            #endregion
                            break;
                        }
                    case 5:
                        {
                            #region Date
                            Console.WriteLine("T A S K 5");
                            Console.WriteLine();
                            AppFunctions.TodayDate();
                            #endregion
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Your choise was incorrect!");
                            Console.WriteLine();
                            break;
                        }

                }
                Console.WriteLine("");
                Console.WriteLine("Once more?");
                Console.WriteLine("Yes - press 'Y', No - press 'N'");
                string s_choise = Console.ReadLine();
                if (s_choise == "Y") exit = false; else exit = true;
                Console.WriteLine();



            }
        }
        #endregion
        }
}
