using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationAboutPerson
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
