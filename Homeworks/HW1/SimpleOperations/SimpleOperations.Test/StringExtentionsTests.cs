using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using NUnit.Framework;
using Newtonsoft.Json.Linq;

namespace CalculateCountOfAppropriateSymbols.UnitTests
{
    [TestFixture]
    public class StringExtentionsTests
    {
        public List<TestResultsData> listOfResults = new List<TestResultsData>();
        private readonly TestTimeLimits testTime = new TestTimeLimits();

        private static readonly object[] TestData =
        {
            new object[] {("aoie"), new [] {'a','o','e','i'}, 4},
            new object[] {("UpUpUp"), new [] {'a','o','e','i'}, 0},
            new object[] {("Unit test"), new[] {'a','o','e','i'}, 2},
        };

        private string GetPathForReport()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);

            return Path.GetDirectoryName(path);
        }

        private void WriteReportToFile(string pathName, JObject jsonObject)
        {
            using (var sw = new StreamWriter(Path.Combine(pathName, "json.txt")))
            {
                var s = jsonObject.ToString(Formatting.Indented);
                sw.Write(s);
            }
        }

        [SetUp]
        public void StartTimer()
        {
            testTime.StartTime = DateTime.Now;
        }

        [TearDown]
        public void GetTestResults()
        {
            testTime.EndTime = DateTime.Now;

            var testResult = TestResultsData.Get(TestContext.CurrentContext, testTime);

            listOfResults.Add(testResult);
        }

        [OneTimeTearDown]
        public void ConvertTestResultsToJsonAndWriteToFile()
        {
            var jsonObject = new JObject {["results"] = JToken.FromObject(listOfResults)};

            var pathName = GetPathForReport();

            if (pathName == null)
            {
                throw new ArgumentNullException($"Such path does not exists!");
            }

            WriteReportToFile(pathName, jsonObject);

        }

        [Test, TestCaseSource(nameof(TestData))]
        public void Should_Return_CountOfSymbols_FromSpecifiedCollection(string inputedString,
                char[] collectionOfChars, int count)
        {
            // Test steps
            var expected = count;
            var actual = inputedString.FindCountOf(collectionOfChars);
            // Check
            Assert.AreEqual(expected, actual);
        }
    }
}