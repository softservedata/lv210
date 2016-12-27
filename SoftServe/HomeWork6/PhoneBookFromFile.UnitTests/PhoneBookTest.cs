using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace PhoneBookFromFile.UnitTests
{
    [TestFixture]
    public class PhoneBookTest
    {
        private static readonly object[] TestDataForGetValueByKey =
        {
            new object[] { new Dictionary<string, string> { { "Dima", "8097802332" }, { "Uliana", "80983030510"} } }
        };

        [TestCase(nameof(TestDataForGetValueByKey))]
        public void ShouldReturnNumberWithCorrectName(Dictionary<string, string> dictionary, )
        {

        }
    }
}
