using System;
using System.Collections.Generic;

namespace hw10
{
    public class Student
    {
        private List<int> marks;
        private string Name { get; set; }

        public List<int> Marks
        {
            get
            {
                return marks;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                marks = value;
            }
        }

        public event MyDel MarkChange;

        public Student()
        {
            Name = "Student";
            Marks = new List<int>();
        }

        public Student(string name, List<int> marks)
        {
           Name = name;
           Marks = marks;
        }

        public void AddMark(MarkAdedEventArgs e)
        {
            Marks.Add(e.Mark);
            MarkChange.Invoke(this, e);      
        }
        
    }
}
