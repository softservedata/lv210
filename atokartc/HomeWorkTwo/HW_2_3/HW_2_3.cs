using System;
using System.Linq;

namespace HomeWorkTwo
{
    /// <summary>
    /// Ввести два цілих числа h  та m, які представляють час доби (година та хвилина). 
    /// Залежності від часу доби вивести привітання («Доброго ранку!», «Доброго дня!», «Доброго вечора!», «Доброї ночі!»)
    /// з 0 до 5:59 — ніч
    /// з 6 до 11:59 — ранок
    /// з 12 до 17:59  — день
    /// з 18 до 23:59 — вечір
    /// </summary>
    public class HW_2_3
    {
        public static void Main()
        {
            Console.Write("Enter hours from 0 to 24: ");
            int h = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter minutes from 0 to 60: ");
            int m = Convert.ToInt32(Console.ReadLine());

            if (Enumerable.Range(0, 24).Contains(h) && Enumerable.Range(0, 60).Contains(m))
            {
                if (Enumerable.Range(0, 5).Contains(h))
                {
                    Console.WriteLine("Good night!");
                }
                if (Enumerable.Range(6, 11).Contains(h))
                {
                    Console.WriteLine("Good morning!");
                }
                if (Enumerable.Range(12, 17).Contains(h))
                {
                    Console.WriteLine("Good afternoon!");
                }
                if (Enumerable.Range(18, 24).Contains(h))
                {
                    Console.WriteLine("Good evening!");
                }
            }
            else
            {
                Console.WriteLine("You enetered incorrect value, please try again!");
                Main();
            }
            Console.ReadKey();
        }
    }
}
