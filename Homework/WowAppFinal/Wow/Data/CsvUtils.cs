using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Wow.Data
{
    public class CsvUtils: IExternalData
    {
        private const char CsvSplitBy = ';';

        public IList<IList<string>> GetAllCells(string path)
        {
            IList<IList<string>> allCells = new List<IList<string>>();

            using (StreamReader streamReader = new StreamReader(path))
            {
                string row;

                while ((row = streamReader.ReadLine()) != null)
                {
                    allCells.Add(row.Split(CsvSplitBy).ToList());
                }
            }

            return allCells;
        }
    }
}
