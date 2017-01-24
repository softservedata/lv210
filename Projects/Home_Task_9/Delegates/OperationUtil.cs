﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public delegate double RealNumber(double number);

    public static class OperationUtil
    {
        public static string[] GetTabulation(RealNumber del, double paramA, double paramB, int steps)
        {
            double arg;
            string[] functions = new string[steps];

            for (int k = 0; k < steps; k++)
            {
                arg = paramA + k * (paramB - paramA) / steps;
                functions[k] = $"F(x) = {del(arg)}";
            }

            return functions;
        }

        public static void WriteToFile(IEnumerable<string> collection, string path, string title)
        {
            File.AppendAllText(path, $"{title}\r\n");
            File.AppendAllLines(path, collection);
        }
    }
}
