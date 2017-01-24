using System;

namespace hw10
{
    public class MarkAdedEventArgs: EventArgs
    {
        public int Mark { get; set; }

        public MarkAdedEventArgs(int mark)
        {
            Mark = mark;
        }
    }
}
