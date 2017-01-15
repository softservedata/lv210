using System;

namespace HomeWorkTwo
{
    /// <summary>
    /// Practical task:
    /// Create Console Application project in VS.
    /// In method Main() write code for solving next task:
    /// read 3 float numbers and check: are they all belong to the range [-5,5].
    /// </summary>
    public class HW_2_4
    {
        public static float GetValueFromConsole()
        {
            float readedVar;
            bool isIntEntered = float.TryParse(Console.ReadLine(), out readedVar);

            if (isIntEntered)
            {
                return readedVar;
            }
            else
            {
                Console.WriteLine("Please, enter float number");
                return GetValueFromConsole();
            }
        }

        public static void Main()
        {
            Console.WriteLine("Enter three float numbers");

            float one = GetValueFromConsole();
            float two = GetValueFromConsole();
            float three = GetValueFromConsole();

            float[] oneTwoThree = { one, two, three };
            bool check = false;

            for (int i = 0; i < oneTwoThree.Length; i++)
            {
                if (oneTwoThree[i] < -5 || oneTwoThree[i] > 5)
                {
                    check = true;
                    Console.WriteLine("Number # {0} are not in the range of [-5;5]", oneTwoThree[i]);
                }
            }

            if (!check)
            {
                Console.WriteLine("All three numbers are in the range of [-5;5]");
            }
            Console.ReadKey();
        }
    }
}

