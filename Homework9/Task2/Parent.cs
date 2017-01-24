using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    //Створити клас Parent з методом OnMarkChange(який отримує int оцінку і виводить її на консоль)
    class Parent
    {
        public void OnMarkChange(int newMark)
        {
            Console.WriteLine("Student has new mark - {0}", newMark);
        }
    }
}
