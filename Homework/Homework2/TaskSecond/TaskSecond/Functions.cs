using System;

namespace AppFunctions
{
    public class AppFunctions
    {
        #region Task1

        public static bool IfHaveTheSameParity(int a, int b)
        {
            if ((a % 2 == 0 && b % 2 == 0) || (a % 2 != 0 && b % 2 != 0)) return true;
            else return false;
        }
        public static int ParityTest()
        {
            Console.Write("a = ");
            string a_str = Console.ReadLine();
            Console.Write("b = ");
            string b_str = Console.ReadLine();
            int a, b;
            try
            {
                a = Convert.ToInt32(a_str);
                b = Convert.ToInt32(b_str);
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect data! Value sholud be numeric.");
                Console.ReadLine();
                return 0;
            }
            Console.WriteLine("");
            Console.WriteLine("Have the same parity - {0}", IfHaveTheSameParity(a, b));
            Console.ReadLine();
            return 0;
        }

        #endregion

        #region Task2
        public static double CicleLength(double r)
        {
            return 2 * Math.PI * r;
        }

        public static double CicleArea(double r)
        {
            return Math.Pow(Math.PI, 2) * r;
        }

        public static double SphereVolume(double r)
        {
            return (4 * Math.PI * Math.Pow(r, 3)) / 3;
        }

        public static int RadiusActions()
        {
            Console.Write("r = ");
            string r_str = Console.ReadLine();
            double r;
            try
            {
                r = Convert.ToDouble(r_str);
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect data! Value sholud be numeric.");
                Console.ReadLine();
                return 0;
            }
            if (r < 0 || r == 0)
            {
                Console.WriteLine("Incorrect data! Value be positive and not equal zero.");
                Console.ReadLine();
                return 0;
            }
            Console.WriteLine("");
            Console.WriteLine("Square - {0}", CicleArea(r));
            Console.WriteLine("Length - {0}", CicleLength(r));
            Console.WriteLine("Sphere volume - {0}", SphereVolume(r));
            Console.ReadLine();
            return 0;
        }




        #endregion

        #region Task3

        public static int Greeting()
        {
            Console.WriteLine("Input time: ");
            Console.Write("Hour -");
            string h_string = Console.ReadLine();
            Console.Write("Minute -");
            string m_string = Console.ReadLine();
            int h, m;
            try
            {
                h = Convert.ToInt32(h_string);
                m = Convert.ToInt32(m_string);
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect data! Value sholud be numeric.");
                Console.ReadLine();
                return 0;
            }
            if (h < 0 || m < 0)
            {
                Console.WriteLine("Incorrect data! All values should be positive.");
                Console.ReadLine();
                return 0;
            }
            if (h > 23 || m > 59)
            {
                Console.WriteLine("Incorrect data! Out of range.");
                Console.ReadLine();
                return 0;
            }
            Console.WriteLine("");
            if (h >= 0 && h < 6) Console.WriteLine("Good night!");
            else if (h >= 6 && h < 12) Console.WriteLine("Good morning!");
            else if (h >= 12 && h < 18) Console.WriteLine("Good afternoon!");
            else Console.WriteLine("Good evening!");
            Console.ReadLine();
            return 0;
        }

        #endregion

        #region Task4
        enum Colors { Red, Blue, Green, Black, Yellow, White, Purple, Rose, Brown };
        public static void FavouriteColor()
        {
           
            Colors myColor = Colors.Yellow;
            Console.WriteLine("My favourite color is {0}", myColor);
            Console.ReadLine();
        }


        #endregion

        #region Task5
        struct Date
        {
            public int day;
            public int month;
            public int year;

            public void ToString()
            {
                Console.WriteLine("The date is {0}.{1}.{2}", day, month, year);
            }
        }

        public static void TodayDate()
        {
            DateTime dt = DateTime.Now;
            Date today;
            today.day = dt.Day;
            today.month = dt.Month;
            today.year = dt.Year;
            today.ToString();
            Console.ReadLine();
        }
        #endregion

    }
}

