﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    /// <summary>
    /// 1. Створити делегат, який отримує і повертає дійсне число.
    /// 2. Створити метод Tabulation, який отримує цей делегат та два числа a, b, n  
    /// і видруковує значення делегату в точках: a+k*(b-a)/n, k=0,1,2,…n 
    /// 3. Викликати метод Tabulation для табуляції функції sin(x), 2x^2+3x* cos(x^3);
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            double paramA = 5, paramB = -5;
            int steps = 3;

            string[] func = OperationUtil.GetTabulation(Math.Sin, paramA, paramB, steps);
            string fileName = "func.txt";
            OperationUtil.WriteToFile(func, fileName, title: "F(x) = sin(x)");

            Func del = arg => 2 * Math.Pow(arg, 2) + 3 * arg * Math.Cos(Math.Pow(arg, 3));
            func = OperationUtil.GetTabulation(del, paramA, paramB, steps);
            OperationUtil.WriteToFile(func, fileName, title: "F(x) = 2x^2+3x*cos(x^3)");
        }
    }
}