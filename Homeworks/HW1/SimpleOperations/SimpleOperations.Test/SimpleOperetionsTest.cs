using System;
using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;

namespace SimpleOperations.Test
{
    [TestFixture]
    public class SimpleOperetionsTest
    {
        #region Fields

        private const string ReportsDirectory = "Reports";
        private const string ReportsFileName = "report.txt";

        private readonly TestResults testResults = new TestResults();
        private readonly TestTimeWatch timeWatch = new TestTimeWatch();

        #endregion 

        #region Tests set up

        [SetUp]
        public void StartTimer()
        {
            timeWatch.Start();
        }

        [TearDown]
        public void GetTestResults()
        {
            timeWatch.End();

            var testResult = new TestResult
            {
                TestName = TestContext.CurrentContext.Test.MethodName,
                StartTime = timeWatch.StartTime,
                EndTime = timeWatch.EndTime,
                Result = TestContext.CurrentContext.Result.Outcome.Status.ToString(),
                ErrorMessage = TestContext.CurrentContext.Result.Message,
                StackTrace = TestContext.CurrentContext.Test.FullName
            };

            testResults.Results.Add(testResult);
        }

        [OneTimeTearDown]
        public void WriteTestsResultsToReportFile()
        {
            var pathName = GetPathForReport(ReportsFileName);
            var json = JsonConvert.SerializeObject(testResults, Formatting.Indented);

            WriteReportToFile(pathName, json);
        }

        #endregion

        #region Tests

        [TestCase(10, 5, 15)]
        public void PositiveAddTest(int firstNumber, int secondNumber, int expectedResult)
        {
            var mathObject = new MathOperations();
            var actualResult = mathObject.Add(firstNumber, secondNumber);
            Assert.AreEqual(expectedResult, actualResult);           
        }

        [TestCase(10, 1, 9)]
        public void PositiveSubtractTest(int firstNumber, int secondNumber, int expectedResult)
        {
            var mathObject = new MathOperations();
            var actualResult = mathObject.Subtract(firstNumber, secondNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(5, 4, 20)]
        public void PositiveProductTest(int firstNumber, int secondNumber, int expectedResult)
        {
            var mathObject = new MathOperations();
            var actualResult = mathObject.Product(firstNumber, secondNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(20, 4, 5)]
        public void PositiveDivisionTest(int firstNumber, int secondNumber, int expectedResult)
        {
            var mathObject = new MathOperations();
            var actualResult = mathObject.Divide(firstNumber, secondNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(-10, -5, -15)]
        public void NegativeAddTest(int firstNumber, int secondNumber, int expectedResult)
        {
            var mathObject = new MathOperations();
            var actualResult = mathObject.Add(firstNumber, secondNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(-10, -1, -9)]
        public void NegativeSubtractTest(int firstNumber, int secondNumber, int expectedResult)
        {
            var mathObject = new MathOperations();
            var actualResult = mathObject.Subtract(firstNumber, secondNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(-5, -4, 20)]
        public void NegativeProductTest(int firstNumber, int secondNumber, int expectedResult)
        {
            var mathObject = new MathOperations();
            var actualResult = mathObject.Product(firstNumber, secondNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(-20, -4, 5)]
        public void NegativeDivisionTest(int firstNumber, int secondNumber, int expectedResult)
        {
            var mathObject = new MathOperations();
            var actualResult = mathObject.Divide(firstNumber, secondNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }

        /*Test cases with NULL numbers*/
        [TestCase(0, 5, 5)]
        public void NullAddTest(int firstNumber, int secondNumber, int expectedResult)
        {
            var mathObject = new MathOperations();
            var actualResult = mathObject.Add(firstNumber, secondNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(5, 0, 5)]
        public void NullSubtractTest(int firstNumber, int secondNumber, int expectedResult)
        {
            var mathObject = new MathOperations();
            var actualResult = mathObject.Subtract(firstNumber, secondNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(5, 0, 0)]
        public void NullProductTest(int firstNumber, int secondNumber, int expectedResult)
        {
            var mathObject = new MathOperations();
            var actualResult = mathObject.Product(firstNumber, secondNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(0, 4, 0)]
        public void NullDivisionTest(int firstNumber, int secondNumber, int expectedResult)
        {
            var mathObject = new MathOperations();
            var actualResult = mathObject.Divide(firstNumber, secondNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(4, 0)]
        public void ExceptionDivisionByZeroTest(int firstNumber, int secondNumber)
        {
            var mathObject = new MathOperations();
            Assert.Throws<DivideByZeroException>(() => mathObject.Divide(firstNumber, secondNumber));
        }

        [TestCase("qwerty")]
        public void ParseAtemptThrowsExceptionTest(string testData)
        {
            Assert.Throws<FormatException>(() => Program.ParseAtempt(testData));
        }

        [TestCase("8", 8)]
        public void ParseAtemptReturnDataTest(string testData, double expectedResult)
        {
            double actualResult = Program.ParseAtempt(testData);

            Assert.AreEqual(expectedResult, actualResult);
        }

        #endregion

        #region Helpers

        private string GetPathForReport(string fileName)
        {
            var baseDirectory = GetTestsBaseDirectory();

            return Path.Combine(baseDirectory, ReportsDirectory, fileName);
        }

        private string GetTestsBaseDirectory()
        {
            var path = TestContext.CurrentContext.TestDirectory;

            return Path.GetDirectoryName(Path.GetDirectoryName(path));
        }

        private void WriteReportToFile(string pathName, string report)
        {
            using (var sw = new StreamWriter(pathName))
            {
                sw.Write(report);
            }
        }

        #endregion
    }
}
