using System;

namespace MaxMin
{
    public class DataParser
    {
        public int Parse(string data)
        {
            int parsedValue;
            var isParseSuccessful = int.TryParse(data, out parsedValue);

            if (!isParseSuccessful)
            {
                throw new FormatException("\nCan't parse data to <int>");
            }

            return parsedValue;
        }
    }
}
