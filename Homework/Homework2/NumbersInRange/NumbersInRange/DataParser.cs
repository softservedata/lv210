using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersInRange
{
    public class DataParser
    {
        public float Parse(string data)
        {
            float parsedValue;

            var isParseSuccessful = float.TryParse(data.Replace('.',','), out parsedValue);

            if (!isParseSuccessful)
            {
                throw new FormatException("\nCan't parse data to <float>");
            }

            return parsedValue;
        }
    }
}
