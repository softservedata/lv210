using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionsWithSquare
{
    public class DataParser
    {
        public double Parse(string data)
        {
            double parsedValue;

            var isParseSuccessful = double.TryParse(data, out parsedValue);

            if (!isParseSuccessful)
            {
                throw new FormatException("\nCan't parse data to <double>");
            }

            return parsedValue;
        }
    }
}
