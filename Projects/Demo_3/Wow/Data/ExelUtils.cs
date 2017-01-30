using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace Wow.Data
{
    public class ExelUtils: IExternalData
    {
        private const int DATA_SHEET = 1;

        public IList<IList<string>> GetAllValues(string path)
        {
            IList<IList<string>> allValues = new List<IList<string>>();
            Excel.Application exlApp = new Excel.Application();
            Excel.Workbook exlWorkbook = exlApp.Workbooks.Open(path);
            Excel._Worksheet exlWorksheet = exlWorkbook.Sheets[DATA_SHEET];
            Excel.Range exlRange = exlWorksheet.UsedRange;
            int rowCount = exlRange.Rows.Count;
            int colCount = exlRange.Columns.Count;
            
            // Iterate over the rows and columns and print to the console as it appears in the file excel is not zero based
            for (int i = 1; i <= rowCount; i++)
            {
                IList<string> rowCells = new List<string>();
                for (int j = 1; j <= colCount; j++)
                {
                    if ((exlRange.Cells[i, j] != null)
                        && (exlRange.Cells[i, j].Value != null))
                    {
                        string cell = exlRange.Cells[i, j].Value.ToString().Trim();
                        rowCells.Add(cell);
                    }
                }
                allValues.Add(rowCells);
            }
            // Cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();
            //
            exlWorkbook.Close();
            Marshal.ReleaseComObject(exlWorkbook);

            // Quit and release
            exlApp.Quit();
            Marshal.ReleaseComObject(exlApp);
            //
            return allValues;
        }
    }
}
