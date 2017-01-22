using System;

namespace Homework10
{
    public class MarkAddedEventArgs: EventArgs
    {
        public int MarkValue { get; private set; }

        public MarkAddedEventArgs(int markValue)
        {
            this.MarkValue = markValue;
        }
    }
}
