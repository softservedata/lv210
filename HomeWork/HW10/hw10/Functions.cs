using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw10
{
    public class Functions
    {
        public static void InvokeAllEvents(Student student, int countOfEvents)
        {
            MarkAdedEventArgs[] e = CreateRandomEvents(countOfEvents);

            for (int i = 0; i < countOfEvents; i++)
            {
                student.AddMark(e[i]);
            }
        }

        private static MarkAdedEventArgs[] CreateRandomEvents(int countOfEvents)
        {
            Random random = new Random();
            MarkAdedEventArgs[] e = new MarkAdedEventArgs[countOfEvents];

            for(int i = 0; i < countOfEvents; i++)
            {
                e[i] = new MarkAdedEventArgs(random.Next(1, 100));
            }

            return e;
        }
    }
}
