using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TaskFirst
{
    using FunctionsForTasks;
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("T A S K  1");
            Console.WriteLine("");
            #region Greeting
            FunctionsForTasks.Greeting();
            #endregion

            Console.WriteLine("T A S K  2");
            Console.WriteLine("");
            #region Operation
            FunctionsForTasks.Arithmetic_operations();
            #endregion

            Console.WriteLine("T A S K  3");
            Console.WriteLine("");
            #region ActionsWithIntValue
            FunctionsForTasks.SquareCalc();
            #endregion

            Console.WriteLine("T A S K  4");
            Console.WriteLine("");
            #region PersonData
            FunctionsForTasks.InformationAboutPerson();
            #endregion
        }
    }
}
