using System.Collections.Generic;

namespace Events
{
    public class Student
    {
        public delegate void MyDel(int m);
        public event MyDel MarkChange;

        private string name;
        private List<int> marks;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public List<int> Marks
        {
            get
            {
                return this.marks;
            }
            set
            {
                this.marks = value;
            }
        }

        public void AddMark(int mark)
        {
            Marks.Add(mark);
            if (MarkChange != null)
            {
                MarkChange(mark);
            }
        }
    }
}
