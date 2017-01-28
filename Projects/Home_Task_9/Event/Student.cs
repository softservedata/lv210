using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event
{
    public class Student
    {
        public delegate void StudentMarkHandler(int mark);
        public event StudentMarkHandler MarkChange;

        private IList<int> _marks;

        public Student(string name, params int[] marks)
        {
            Name = name;
            Marks = new List<int>(marks);
        }

        public string Name { get; }
        public IList<int> Marks
        {
            get { return _marks; }
            private set
            {
                if (value.Any(mark => (mark < 1) || (mark > 12)))
                {
                    throw new ArgumentException("Incorrect mark value!");
                }

                _marks = value;
            }
        }

        public void AddMark(int mark)
        {
            _marks.Add(mark);
            if (MarkChange != null)
                MarkChange.Invoke(mark);
        }
    }
}
