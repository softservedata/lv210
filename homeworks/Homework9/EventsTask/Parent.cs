using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsTask
{
    public class Parent
    {
        public void OnMarkChanged(int mark)
        {
            Console.WriteLine(mark);
        }
    }
}
