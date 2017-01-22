using System;
using System.Collections.Generic;
using System.IO;

namespace Homework10
{
    public delegate void MarkAddedEventHandler(object sender, MarkAddedEventArgs e);

    class Program
    {
        public static string GetPath(string fileName)
        {
            var directory = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            return Path.Combine(directory, fileName);
        }

        public static MarkAddedEventArgs[] CreateRandomEventArgs(int n)
        {
            var random = new Random();
            var e = new MarkAddedEventArgs[n];

            for (var i = 0; i < n; i++)
            {
                e[i] = new MarkAddedEventArgs(random.Next(1, 5));
            }

            return e;
        }

        public static void InvokeEvent(Student student, MarkAddedEventArgs[] e, int countOfTimes)
        {
            for (var i = 0; i < countOfTimes; i++)
            {
                student.AddMark(e[i]);
            }
        }

        static void Main(string[] args)
        {
            var path = GetPath("ResultsOfHandlingEvent.txt");
            File.WriteAllText(path, string.Empty);

            var student = new Student("Ivan", new List<int>() {4, 5, 4, 4, 5});
            var parent = new Parent(path);
            student.MarkChanged+=parent.OnMarkChange;

            int count = 3;
            var e = CreateRandomEventArgs(count);

            InvokeEvent(student, e, count);
        }
    }
}
