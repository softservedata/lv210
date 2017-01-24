using System;

namespace DelegatesAndEvents
{
    class Parent
    {
        Student student;

        public Parent(Student student)
        {
            this.student = student;
        }

        public void OnMarkChange(int mark)
        {
            Console.WriteLine("Student {0} has got new mark : {1}", student.Name, mark);
        }
    }
}
