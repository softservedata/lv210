using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    //  Створити делегат void MyDel(int m)
    //  В Main Створити студента, батька, підписати батьківський метод OnMarkChange на подію студента MarkChange.
    //  Викликати кілька разів метод AddMark для студента

    public delegate void MyDel(int m);

    public class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student
            {
                Name = "Petro",
                Marks = { 3, 4, 5}
            };

            Parent parent = new Parent();
            student1.MarkChange += parent.OnMarkChange;

            student1.AddMark(5);
            student1.AddMark(3);
            student1.AddMark(4);
            Console.ReadLine();
        }
    }
}
