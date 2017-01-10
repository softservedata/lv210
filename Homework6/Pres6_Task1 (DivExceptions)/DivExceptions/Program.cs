﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DivFile
{
    class Program
    {
        static double Div(double n1, double n2)
        {
            double number1 = n1;
            double number2 = n2;
            double division = number1 / number2;
            return division;
        }

        static void Main(string[] args)
        {
            if (File.Exists("C:\\Users\\Andriy\\Documents\\Visual Studio 2013\\Projects\\Pres6_Task2 (DivFile)\\data.txt") == true)
            {
                StreamReader reader = new StreamReader("C:\\Users\\Andriy\\Documents\\Visual Studio 2013\\Projects\\Pres6_Task2 (DivFile)\\data.txt");
                string line;
                double[] numbers = new double[2];
                int i = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    if (i < 2)
                    {
                        try
                        {
                            numbers[i] = Convert.ToDouble(line);


                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Data in 'data.txt' has wrong format");
                        }
                        i++;
                    }
                    Console.WriteLine(string.Join(",", numbers));
                }
                reader.Close();
                double result = Div(numbers[0], numbers[1]);
                using (StreamWriter writer = new StreamWriter("C:\\Users\\Andriy\\Documents\\Visual Studio 2013\\Projects\\Pres6_Task2 (DivFile)\\result.txt"))
                {
                    writer.WriteLine(result);

                    File.WriteAllText("C:\\Users\\Andriy\\Documents\\Visual Studio 2013\\Projects\\Pres6_Task2 (DivFile)\\result2.txt", result.ToString());
                }
            }
            else
            {
                Console.WriteLine("File does not exist");

            }

        }
    }
}
