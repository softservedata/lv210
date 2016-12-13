using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    public class FloatNumbers
    {
        public static bool isInRange(float []numbers,float leftBound, float rightBound)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] <leftBound || numbers[i] > rightBound) return false;
            }
            return true;
              
        }

        static void Main(string[] args)
        {
            float[] numbers = new float[3];
            float rightBound = 5.0F;
            float leftBound = -5.0F;
            Console.WriteLine("Input float numbers(use ',' as delimiter)");
            for (int i=0;i<3;i++)
            {
                Console.Write("Number[{0}]=", i + 1);
                numbers[i] = float.Parse(Console.ReadLine());
                            }
            if (isInRange(numbers, leftBound, rightBound)) Console.WriteLine("Numbers are in range [{0},{1}]", leftBound, rightBound);
            else Console.WriteLine("Numbers are out of range [{0},{1}]", leftBound, rightBound);
            Console.ReadKey();
        }
    }

