using NLog;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace Wow.Data
{
    public class ExcelUtils : IExternalData
    {
        private const int DATA_SHEET = 1;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public IList<IList<string>> GetAllCells(string path)
        {
            IList<IList<string>> allCells = new List<IList<string>>();

            logger.Debug("Start GetAllCells(string path), path = " + path);

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(path);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[DATA_SHEET];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            for (int i = 1; i <= rowCount; i++)
            {
                IList<string> rowCells = new List<string>();
                for (int j = 1; j <= colCount; j++)
                {
                    if ((xlRange.Cells[i, j] != null)
                        && (xlRange.Cells[i, j].Value2 != null))
                    {
                        String cell = xlRange.Cells[i, j].Value.ToString().Trim();
                        logger.Trace("Start Add Cell = " + cell);
                        rowCells.Add(cell);
                        logger.Trace("Done Add Cell = " + cell);
                    }
                }
                allCells.Add(rowCells);
            }
            // Cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);
            // Quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
            //
            logger.Debug("Done GetAllCells(string path), path = " + path);
            return allCells;
        }

    }
}
