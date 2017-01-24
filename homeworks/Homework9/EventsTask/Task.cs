using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsTask
{
    public class Task
    {
        static void Main(string[] args)
        {
            Student student = new Student("Roman");
            Parent parent = new Parent();
            student.MarkChange += parent.OnMarkChanged;
            student.AddMark(1);
            student.AddMark(5);

            Console.ReadLine();
        }
    }
}
