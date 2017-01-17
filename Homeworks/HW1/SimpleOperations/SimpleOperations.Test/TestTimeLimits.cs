using System;

namespace SimpleOperations.Test
{
    public class TestTimeLimits
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public TestTimeLimits()
        {
        }

        public TestTimeLimits(DateTime startTime, DateTime endTime)
        {
            this.StartTime = startTime;
            this.EndTime = endTime;
        }

        public TimeSpan TestExecutionDuration()
        {
            return this.EndTime.Subtract(this.StartTime);
        }
    }
}
