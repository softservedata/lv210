﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9
{
    public delegate double NumberDelegate(double number);

    public class Tabulator
    {
        /// <summary>
        /// Method tabulates given function in given interval
        /// from a to b.
        /// </summary>
        /// <param name="del">Function</param>
        /// <param name="a">Lower bound</param>
        /// <param name="b">Upper bound</param>
        /// <param name="n">Count of steps</param>

        public static void Tabulate(NumberDelegate del,double a, double b, int n)
        {
            for(int i = 0; i < n; i++)
            {
               double x = a + i * (b - a) / n;
               double fx = del(x);
               Console.WriteLine("x = {0}, f(x) = {1}", x, fx);
            }
        }
    }
}
