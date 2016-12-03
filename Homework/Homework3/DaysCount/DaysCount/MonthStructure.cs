using System;

namespace MonthStructure
{
    

    public class StructureAndFunctions
    {
        public struct Month
        {
            public string Name;
            public int number;
            public int days_number;
        }

        public static int[] days_count = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        public static string[] monthsName = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        public static void InitializeStructure(Month[] monthsOfYear)
        {
            for(int i =0; i<monthsOfYear.Length; i++)
            {
                monthsOfYear[i].Name = monthsName[i];
                monthsOfYear[i].days_number = days_count[i];
                monthsOfYear[i].number = i + 1;
            }
        }

        public static Month GetMonth(Month [] monthsOfYear, int number)
        {
            Month result = new Month();

            for(int i =0; i<monthsOfYear.Length; i++)
            {
                if (monthsOfYear[i].number == number)
                {
                    result = monthsOfYear[i];
                    break;
                }
            }

            return result;
        }

    }
    
}
   