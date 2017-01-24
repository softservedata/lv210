using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    //Створити клас Student, з полями name та marks(типу list<int>), подією MarkChange типу MyDel та 
    //методом AddMark(додає нову оцінку до marks, перевіряє чи хтось підписався на подію і викликає її з новою оцінкою)

    public class Student
    {
        private string name;
        private List<int> marks;
        public event MyDel MarkChange;

        public Student()
        {
            name = null;
            marks = new List<int>();
        }

        public string Name
        {
            get {return name;}
            set { name = value;}
        }

        public List<int> Marks
        {
            get { return marks; }
            set { marks = value; }
        }

        public void AddMark(int newMark)
        {
            marks.Add(newMark);
            MarkChange(newMark);
        }
    }
}
