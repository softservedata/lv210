using System;

namespace EventsTask
{
    /// <summary>
    /// Створити делегат void MyDel(int m) 
    /// Створити клас Student, з полями name та marks(типу list<int>), подією MarkChange типу MyDel та методом AddMark(додає нову оцінку до marks, перевіряє чи хтось підписався на подію і викликає її з новою оцінкою)
    ///Створити клас Parent з методом OnMarkChange(який отримує int оцінку і виводить її на консоль)
    ///В Main Створити студента, батька, підписати батьківський метод OnMarkChange на подію студента MarkChange.Викликати кілька разів метод AddMark для студента
    /// </summary>
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
