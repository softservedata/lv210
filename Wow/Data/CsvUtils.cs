using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
