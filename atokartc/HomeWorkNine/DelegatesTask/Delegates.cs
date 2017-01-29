using System;

namespace DelegatesTask
{
    /// <summary>
    /// Task 1
    /// 1. Створити делегат, який отримує і повертає дійсне число.
    /// 2. Створити метод Tabulation, який отримує цей делегат та два числа a, b, n  і видруковує значення делегату в точках: a+k*(b-a)/n, k=0,1,2,…n 
    /// 3. Викликати метод Tabulation для табуляції функції sin(x), 2x^2+3x* cos(x^3);
    /// </summary>
    public class Delegates
    {
        public delegate double MyDelegate(double val);

        public static void Tabulation(MyDelegate myDel, double a, double b, double n)
        {
            double rez;

            for (int k = 0; k < n; k++)
            {
                rez = a + k * (b - a) / n;
                Console.WriteLine("Func(x) = {0}", myDel(rez));
                Console.ReadKey();
            }
        }

        public static double Sin(double var)
        {
            return Math.Sin(var);
        }

        public static double Function(double var)
        {
            return 2 * Math.Pow(var, 2) + 3 * var * Math.Cos(Math.Pow(var, 3));
        }

        public static void Main()
        {
            MyDelegate myDel = new MyDelegate(Sin);
            MyDelegate myDelTwo = new MyDelegate(Function);

            Tabulation(myDel, 2, 5, 6);
            Tabulation(myDelTwo, 2, 6, 7);
        }
    }
}
