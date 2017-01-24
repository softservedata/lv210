using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event
{
    /// <summary>
    /// Створити делегат void MyDel(int m) 
    /// Створити клас Student, з полями name та marks(типу list(int)), подією MarkChange типу MyDel 
    /// та методом AddMark(додає нову оцінку до marks, перевіряє чи хтось підписався на подію і викликає її з новою оцінкою)
    /// Створити клас Parent з методом OnMarkChange(який отримує int оцінку і виводить її на консоль)
    /// В Main Створити студента, батька, підписати батьківський метод OnMarkChange на подію студента MarkChange.
    /// Викликати кілька разів метод AddMark для студента
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Taras", 10, 11, 12, 9);
            Parent parent = new Parent("marksReport.txt");

            student.MarkChange += parent.OnMarkChange;
            student.AddMark(12);
            student.AddMark(8);
        }
    }
}
