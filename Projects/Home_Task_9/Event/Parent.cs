using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event
{
    public class Parent
    {
        public Parent(string reportName)
        {
            ReportName = reportName;
        }

        public string ReportName { get; }

        public void OnMarkChange(int mark) =>
            File.AppendAllText(ReportName, $"{DateTime.Today.ToShortDateString()} new mark added: {mark}\r\n");
    }
}
