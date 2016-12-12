using NUnit.Framework;

namespace InformationAboutPerson.UnitTests
{
    [TestFixture]
    public class PersonValidatorTests
    {
        private static readonly object[] InvalidAge =
        {
            new object[] {-20},
            new object[] {-1},
            new object[] {0},
            new object[] {200},
        };
        
        [Test, TestCaseSource(nameof(InvalidAge))]
        public void Should_Return_False_When_Age_IsLess_OrEqualZero_OrGreater150(int age)
        {
            //Preconditions
            var validator = new PersonValidator();
            var person = new Person("Some name", age);
            //Test steps
            var expected = false;
            var actual = validator.Validate(person).IsValid;
            //Check
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        [TestCase("")]
        [TestCase("I1go2r")]
        [TestCase("I*&ra")]
        public void Should_Return_False_When_NameIsInvalid(string name)
        {
            //Preconditions
            var age = 13;
            var validator = new PersonValidator();
            var person = new Person(name, age);
            //Test steps
            var expected = false;
            var actual = validator.Validate(person).IsValid;
            //Check
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("Uliana", 21)]
        [TestCase("Bogdan", 10)]
        public void Should_Return_True_When_Data_IsValid(string name, int age)
        {
            //Preconditions
            var validator = new PersonValidator();
            var person = new Person(name, age);
            //Test steps
            var expected = true;
            var actual = validator.Validate(person).IsValid;
            //Check
            Assert.AreEqual(expected, actual);
        }
    }
}
