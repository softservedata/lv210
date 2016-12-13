using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxMin
{
    public class Methods
    {
        public static bool Check(int[] numbers)
        {
            bool result = false;
            for(int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i - 1] != numbers[i])
                    result = true;
            }
            return result;
        }
        public static int Max(int[] numbers)
        {
            int max = int.MinValue;
            for (int i = 0; i < numbers.Length; i++)
                if (numbers[i] > max)
                    max = numbers[i];

            return max;
        }
        public static int Min(int[] numbers)
        {
            int min = int.MaxValue;
            for (int i = 0; i < numbers.Length; i++)
                if (numbers[i] < min)
                    min = numbers[i];

            return min;
        }
    }
}
