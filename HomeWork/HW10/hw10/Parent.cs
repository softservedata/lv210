using System;

namespace hw10
{
    public class Parent
    {
        private string Name { get; set; }

        public Parent()
        {
            Name = "Parent";
        }

        public Parent(string name)
        {
            Name = name;
        }

        public void OnMarkChange(object sender, MarkAdedEventArgs e)
        {
            Console.WriteLine("Mark is {0}", e.Mark);
        }
    }
}
