using System;
using Newtonsoft.Json;
using NUnit.Framework;

namespace SimpleOperations.Test
{
    // Builder interfaces
    public interface ITestName
    {
        IStartTime SetTestName(string testName);
    }

    public interface IStartTime
    {
        IEndTime SetStartTime(DateTime starTime);
    }

    public interface IEndTime
    {
        IResult SetEndTime(DateTime endTime);
    }

    public interface IResult
    {
        IErrorMessage SetResult(string result);
    }

    public interface IErrorMessage
    {
        IStackTrace SetIsErrorMessage(string errorMessage);
    }

    public interface IStackTrace
    {
        IBuilder SetStackTrace(string stackTrace);
    }

    public interface IBuilder
    {
        TestResultsData Build();
    }

    public interface ITestResultsData
    {
        string GetTestName();
        DateTime GetStartTime();
        DateTime GetEndTime();
        string GetResult();
        string GetErrorMessage();
        string GetStackTrace();
    }

    public class TestResultsData : ITestResultsData, ITestName, IStartTime, IEndTime, IResult, IErrorMessage, IStackTrace, IBuilder
    {
        [JsonProperty]
        private string testName;
        [JsonProperty]
        private DateTime starTime;
        [JsonProperty]
        private DateTime endTime;
        [JsonProperty]
        private string result;
        [JsonProperty]
        private string errorMessage;
        [JsonProperty]
        private string stackTrace;

        // Static factory
        public static ITestName Get()
        {
            return new TestResultsData();
        }

        public static TestResultsData Get(TestContext testContext, TestTimeLimits timeLimits)
        {
            return TestResultsData.Get()
                .SetTestName(testContext.Test.MethodName)
                .SetStartTime(timeLimits.StartTime)
                .SetEndTime(timeLimits.EndTime)
                .SetResult(testContext.Result.Outcome.Status.ToString())
                .SetIsErrorMessage(testContext.Result.Message)
                .SetStackTrace(testContext.Test.FullName)
                .Build();
        }

        public string GetTestName()
        {
            return this.testName;
        }

        public DateTime GetStartTime()
        {
            return this.starTime;
        }

        public DateTime GetEndTime()
        {
            return this.endTime;
        }

        public string GetResult()
        {
            return this.result;
        }

        public string GetErrorMessage()
        {
            return this.errorMessage;
        }

        public string GetStackTrace()
        {
            return this.stackTrace;
        }

        public IStartTime SetTestName(string testName)
        {
            this.testName = testName;
            return this;
        }

        public IStackTrace SetIsErrorMessage(string errorMessage)
        {
            this.errorMessage = errorMessage;
            return this;
        }

        public TestResultsData Build()
        {
            return this;
        }

        public IEndTime SetStartTime(DateTime starTime)
        {
            this.starTime = starTime;
            return this;
        }

        public IResult SetEndTime(DateTime endTime)
        {
            this.endTime = endTime;
            return this;
        }

        public IErrorMessage SetResult(string result)
        {
            this.result = result;
            return this;
        }

        public IBuilder SetStackTrace(string stackTrace)
        {
            this.stackTrace = stackTrace;
            return this;
        }
    }
}
