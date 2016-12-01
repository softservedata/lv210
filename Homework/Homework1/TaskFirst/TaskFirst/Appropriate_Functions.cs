using System;

namespace FunctionsForTasks
{
    public class FunctionsForTasks
    {
        #region task1
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Sub(int a, int b)
        {
            return a - b;
        }

        public static int Mul(int a, int b)
        {
            return a * b;
        }

        public static double Div(int a, int b)
        {
            if (b != 0) return (Convert.ToDouble(a) / b);
            else
            {
                Console.WriteLine("Divition is impossible!");
                return 0;
            }
        }

        public static void Arithmetic_operations()
        {

            Console.Write("a = ");
            Console.ReadLine();
            string s = Console.ReadLine();
            try
            {
                int a = Convert.ToInt32(s);
                Console.Write("b = ");
                s = Console.ReadLine();
                int b = Convert.ToInt32(s);
                Console.WriteLine("");
                Console.WriteLine("{0}+{1}={2}", a, b, Add(a, b));
                Console.WriteLine("{0}-{1}={2}", a, b, Sub(a, b));
                Console.WriteLine("{0}*{1}={2}", a, b, Mul(a, b));
                Console.WriteLine("{0}/{1}={2}", a, b, Div(a, b));
            }
            catch(Exception)
            {
                Console.WriteLine("Incorrect data!");
            }
            finally
            {
                Console.ReadLine();
            }

            
        }

        public static void Greeting()
        {
            Console.WriteLine("How are you?");
            string s = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("You are {0}!",s);
            Console.Read();
        }
        #endregion

        #region task2
        public static int Square(int a)
        {
            return a * a;
        }

        public static int Perimeter(int a)
        {
            return 4 * a;
        }

        public static void SquareCalc()
        {
            Console.WriteLine("Square:");
            Console.Write("a = ");
            string s = Console.ReadLine();
            try
            {
                int a = Convert.ToInt32(s);
                if (a == 0 || a < 0) Console.WriteLine("Incorrect data!");
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Area = {0}", Square(a));
                    Console.WriteLine("Periment = {0}", Perimeter(a));
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect data!");
            }
            finally
            {
                Console.ReadLine();
            }
        }

        public static void InformationAboutPerson()
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Console.WriteLine("How old are you, {0}?", name);
            string s = Console.ReadLine();
            try
            {
                int age = Convert.ToInt32(s);
                if(age==0 || age<0) Console.WriteLine("Incorrect data!");
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Your name is {0}", name);
                    Console.WriteLine("You are {0} years old", age);
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Incorrect data!");
            }
            finally
            {
                Console.Read();
            }
            
        }

        #endregion
    }
}

