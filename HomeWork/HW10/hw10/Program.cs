using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw10
{
    public delegate void MyDel(object sender, MarkAdedEventArgs e);  

    public class Program
    {
        static void Main(string[] args)
        {
            int countOfEvents = 3;

            Student student = new Student("Oleg", new List<int>() { 4, 3, 4, 5 });
            Parent parent = new Parent();

            student.MarkChange += parent.OnMarkChange;

            Functions.InvokeAllEvents(student, countOfEvents);
        }
    }
}
