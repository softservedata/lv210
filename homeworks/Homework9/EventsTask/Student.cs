using System;
using System.Collections.Generic;

namespace EventsTask
{
    public delegate void MyDel(int m);
    public class Student
    {
        public List<int> Marks { get; private set; }
        public string Name { get; set; }
        public event MyDel MarkChange;
        
        public Student(string name)
        {
            Name = name;
            Marks = new List<int>();
        }

        public void AddMark(int mark)
        {
            if (MarkChange != null)
            {
                Marks.Add(mark);
                MarkChange(mark);
            }
        }
    }
}
