using System.IO;

namespace Homework10
{
    public class Parent
    {
        public string Email { get; private set; }

        public Parent(string email)
        {
            this.Email = email;
        }

        public void OnMarkAdded(object sender, MarkAddedEventArgs e)
        {
            string[] lines = {$"New mark is {e.MarkValue}"};
            File.AppendAllLines(Email, lines);
        }
    }
}
