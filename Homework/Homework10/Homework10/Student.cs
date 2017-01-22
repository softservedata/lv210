using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework10
{
    public class Student
    {
        private List<int> marks;
        public string Name { get; private set; }

        public List<int> Marks
        {
            get
            {
                return marks;
            }
            protected set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                if (value.Any(x => (x >= 6) || (x <= 0)))
                {
                    throw new ArgumentException("Marks values are incorrect!");
                }

                marks = value;
            }
        }

        public event MarkAddedEventHandler MarkChanged;

        public Student()
        {
            this.Name = null;
            this.Marks = new List<int>();
        }

        public Student(string name, List<int> marks)
        {
            this.Name = name;
            this.Marks = marks;
        }
        public void AddMark(MarkAddedEventArgs e)
        {
            this.Marks.Add(e.MarkValue);
            this.MarkChanged?.Invoke(this, e);
        }
    }
}