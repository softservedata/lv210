using System.Collections.Generic;

namespace DelegatesAndEvents
{
    delegate void MyDel(int mark);

    class Student
    {
        IList<int> marks;
        public event MyDel MarkChange;
        public string Name { get; set; }

        public Student()
        {
            marks = new List<int>();
        }

        public Student(string name)
        {
            this.Name = name;
            marks = new List<int>();
        }

        public void AddMark(int newMark)
        {
            marks.Add(newMark);
            MarkChange(newMark);
        }
    }
}
