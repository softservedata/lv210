using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Wow.Data
{
    public class CsvUtils : IExternalData
    {
        private const char CSV_SPLIT_BY = ';';

        public IList<IList<string>> GetAllCells(string path)
        {
            IList<IList<string>> allCells = new List<IList<string>>();
            string row;
            //
            using (StreamReader streamReader = new StreamReader(path))
            {
                while ((row = streamReader.ReadLine()) != null)
                {
                    allCells.Add(row.Split(CSV_SPLIT_BY).ToList());
                }
            }
            return allCells;
        }
    }
}
