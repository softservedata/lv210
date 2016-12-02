using System;

namespace AppropriateFunctions
{
    public class Functions
    {
        public static string EachSecondSymbol(string data)
        {
            string result = "";
            for (int i = 0; i < data.Length; i++)
            {
                if ((i+1) % 2 == 0) result += data[i];
            }
            return result;
        }
    }
}