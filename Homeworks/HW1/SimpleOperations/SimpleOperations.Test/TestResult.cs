using System;
using Newtonsoft.Json;

namespace SimpleOperations.Test
{
    public class TestResult
    {
        [JsonProperty("testName")]
        public string TestName { get; set; }

        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }

        [JsonProperty("stackTrace")]
        public string StackTrace { get; set; }

        [JsonProperty("startTime")]
        public DateTime StartTime { get; set; }

        [JsonProperty("endTime")]
        public DateTime EndTime { get; set; }
    }
}
