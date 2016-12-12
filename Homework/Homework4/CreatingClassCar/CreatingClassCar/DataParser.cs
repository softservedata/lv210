using System;

namespace CreatingClassCar
{
    public class DataParser
    {
        public double Parse(string data)
        {
            double parsedValue;

            var isParseSuccessful = double.TryParse(data.Replace('.', ','), out parsedValue);

            if (!isParseSuccessful)
            {
                throw new FormatException("\nCan't parse data to <double>");
            }

            return parsedValue;
        }
    }
}
