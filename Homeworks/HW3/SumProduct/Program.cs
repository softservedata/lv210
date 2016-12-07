using System;

namespace SumProduct
{
    class Program
    {
        public static bool isPositive(int[] data)
        {
            bool isPositive = true;
            for (int i = 0; i < 5; i++)
            {
                if (data[i] <= 0)
                {
                    isPositive = false;
                    break;
                }
            }
            return isPositive;
        }
        public static void Sum(int[] data)
        {
            int sum = 0;
            for (int i = 0; i < 5; i++)
            {
                sum += data[i];
            }
            Console.WriteLine("Sum of of first 5 elements: {0}", sum);
        }
        public static void Product(int[] data)
        {
            int prod = 1;
            for (int i = data.Length - 1; i >= 5; i--)
            {
                prod *= data[i];
            }
            Console.WriteLine("Product of of last 5 elements: {0}", prod);
        }
        static void Main(string[] args)
        {
            int[] intData = new int[10];
            Console.WriteLine("Input 10 integer numbers");
            string[] str = Console.ReadLine().Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < (intData.Length < str.Length ? intData.Length : str.Length); ++i)
                intData[i] = Convert.ToInt32(str[i]);
            bool temp = isPositive(intData);
            if (temp)
            {
                Sum(intData);
            }
            else
                Product(intData);
            Console.ReadLine();
        }
    }
}
