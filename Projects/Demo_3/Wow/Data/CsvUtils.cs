using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Wow.Data
{
    public class CsvUtils : IExternalData
    {
        private const char SPLIT_CHAR = ';';

        public IList<IList<string>> GetAllValues(string path)
        {
            IList<IList<string>> allValues = new List<IList<string>>();
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    allValues.Add(line.Split(SPLIT_CHAR).ToList());
                }
            }
            return allValues;
        }
    }
}