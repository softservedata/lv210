﻿using System;
using System.Linq;

namespace HierarchyOfGeometricShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Point[] p = { new Point(6, 2), new Point(2, 2), new Point(2, 6), new Point(6, 6) };
            //Point[] p = { new Point(10, 5), new Point(4, 4), new Point(7, 6), new Point(6, 7) };
            //Point[] p = { new Point(3, 2), new Point(5, 6), new Point(9, 6), new Point(11, 2) };
            //Point[] p = { };
            //Point[] p = { new Point(4, 4), new Point(6, 7), new Point(7, 6), new Point(10, 5) };
            //Point[] p = { new Point(10, 5), new Point(10, 5), new Point(10, 5), new Point(7, 8) };
            //Point[] p = { new Point(8, 2), new Point(11, 4), new Point(10, 10), new Point(2, 2), new Point(15, 8), new Point(5, 8), new Point(10, 5) };
            //Point[] p = { new Point(10, 5), new Point(4, 4), new Point(7, 6), new Point(8, 2) };

            var quadrangle = new Quadrangle(p);
            var validationsResults = quadrangle.Validate();
            quadrangle.Area();

            if (validationsResults.Any())
            {
                foreach (var validationResult in validationsResults)
                {
                    Console.WriteLine(validationResult.ErrorMessage);
                }
            }
            else
            {
                Console.WriteLine(quadrangle);
            }

            Console.ReadLine();
        }
    }
}