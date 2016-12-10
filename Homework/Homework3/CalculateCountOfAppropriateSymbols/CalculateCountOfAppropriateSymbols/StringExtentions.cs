using System.Linq;

namespace CalculateCountOfAppropriateSymbols
{
    public static class StringExtentions
    {
        public static int FindCountOf(this string enteredString, char[] сollectionOfChars)
        {
            int count = 0;
            foreach (char character in enteredString)
            {
                var isFromCollection = сollectionOfChars.Contains(character);

                if (isFromCollection)
                {
                    count++;
                }
            }
            return count;
        }
    }
}