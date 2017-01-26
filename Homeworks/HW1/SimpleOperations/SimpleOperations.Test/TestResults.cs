using System.Collections.Generic;
using Newtonsoft.Json;

namespace SimpleOperations.Test
{
    public class TestResults
    {
        public TestResults()
        {
            Results = new List<TestResult>();
        }

        [JsonProperty("results")]
        public List<TestResult> Results { get; }
    }
}