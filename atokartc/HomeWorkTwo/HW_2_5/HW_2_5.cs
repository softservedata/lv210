using System;
 
namespace HomeWorkTwo
{
    /// <summary>
    /// Create Console Application project in VS.
    /// In method Main() write code for solving next task:
    /// read 3 integres and write max and min of them.
    /// </summary>
    /// 
    public class HW_2_5
    {
        public static int GetValueFromConsole()
        {
            int readedVar;
            bool isIntEntered = Int32.TryParse(Console.ReadLine(), out readedVar);

            if (isIntEntered)
            {
                return readedVar;
            }
            else
            {
                Console.WriteLine("Please, enter an integer");
                return GetValueFromConsole();
            }
        }

        public int MaxValue(int one, int two, int three)
        {
            if (one > two && one > three)
            {
                return one;
            }
            else if (two > three)
            {
                return two;
            }
            else
            {
                return three;
            }
        }

        public int MinValue(int one, int two, int three)
        {
            if (one < two && one < three)
            {
                return one;
            }
            else if (two < three)
            {
                return two;
            }
            else
            {
                return three;
            }
        }

        public static void Main()
        {
            HW_2_5 homeWork = new HW_2_5();

            Console.WriteLine("Enter three integer numbers:");
            int one = GetValueFromConsole();
            int two = GetValueFromConsole();
            int three = GetValueFromConsole();

            int maxOfThreeValue = homeWork.MaxValue(one, two, three);
            int minOfThreeValue = homeWork.MinValue(one, two, three);

            Console.WriteLine("MaxValue value of three is: {0}", maxOfThreeValue);
            Console.WriteLine("MinValue value of three is: {0}", minOfThreeValue);
            Console.ReadKey();
        }
    }
}
