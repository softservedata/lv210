using System;

namespace Events
{
    public class Parent
    {
        public void OnMarkChange(int mark)
        {
            Console.WriteLine("Mark is: {0}", mark);
            Console.ReadKey();
        }
    }
}
