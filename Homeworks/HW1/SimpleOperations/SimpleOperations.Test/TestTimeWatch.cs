using System;

namespace SimpleOperations.Test
{
    public class TestTimeWatch
    {
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public void Start()
        {
            StartTime = DateTime.Now;
        }

        public void End()
        {
            EndTime = DateTime.Now;
        }

        public TimeSpan GetExecutionTime()
        {
            return this.EndTime.Subtract(this.StartTime);
        }
    }
}
