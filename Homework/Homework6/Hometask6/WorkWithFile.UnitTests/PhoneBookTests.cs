using System;
using System.Collections.Generic;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace WorkWithFile.UnitTests
{
    [TestFixture]
    public class PhoneBookTests
    {
        private static readonly object[] TestDataForReadFromFileFunction =
        {
            new object[]
            {
                @"D:\Курси\c_sharp hometasks\Hometask6\WorkWithFile.UnitTests\phones.txt",
                new Dictionary<string, string>
                {
                    {"Uliana", "+380687609571"},
                    {"Yana", "0975757111"}
                }
            }
        };

        private static readonly object[] TestDataForGettingPhoneFunction =
        {
            new object[]
            {
                "Uliana", new Dictionary<string, string>
                {
                    {"Uliana", "+380687609571"},
                    {"Yana", "0975757111"}
                },
                "+380687609571"
            }
        };

        private static readonly object[] IncorrectTestDataForGettingPhoneFunction =
        {
            new object[]
            {
                "Inna", new Dictionary<string, string>
                {
                    {"Uliana", "+380687609571"},
                    {"Yana", "0975757111"}
                }
            }
        };

        private static readonly object[] TestDataForChangingFormatOfNumberFunction =
        {
            new object[]
            {
                @"^80\d{9}", new Dictionary<string, string>
                {
                    {"Uliana", "+380687609571"},
                    {"Yana", "80975757111"},
                    {"Orest", "80975744111"}
                },

                new Dictionary<string, string>
                {
                    {"Uliana", "+380687609571"},
                    {"Yana", "+380975757111"},
                    {"Orest", "+380975744111"}
                }
            }
        };

        /// <summary>
        /// <para> This test verifies whether data about persons's phone numbers of is readed correctly. </para>
        /// </summary>

        [Test, TestCaseSource(nameof(TestDataForReadFromFileFunction))]
        public void Should_Read_Data_From_File_Correctly(string path, Dictionary<string, string> expectedPhoneBook)
        {
            var phoneBook = new PhoneBook();

            phoneBook.ReadDataFromFile(path);

            var expected = expectedPhoneBook;
            var actual = phoneBook.BookOfPhones;

            CollectionAssert.AreEqual(expected, actual, "Collections are not equal!");
        }

        /// <summary>
        /// <para> This test verifies whether correct phone number of person is returned. </para>
        /// </summary>

        [Test, TestCaseSource(nameof(TestDataForGettingPhoneFunction))]
        public void Should_Find_The_Number_Of_Specified_Person(string personName,
            Dictionary<string, string> testPhoneBook, string phone)
        {
            var phoneBook = new PhoneBook(testPhoneBook);

            var expected = phone;
            var actual = phoneBook.FindNumberByPersonName(personName);

            Assert.AreEqual(expected, actual, "Phone numbers are not equal!");
        }

        /// <summary>
        /// <para> This test throws exeption when there is no an appropriate person in phone book. </para>
        /// </summary>

        [Test, TestCaseSource(nameof(IncorrectTestDataForGettingPhoneFunction))]
        public void Should_Throw_Exeption_When_Person_IsNot_InPhoneBook(string personName,
            Dictionary<string, string> testPhoneBook)
        {
            Assert.Throws<ArgumentException > (() => new PhoneBook(testPhoneBook).FindNumberByPersonName(personName));
        }

        /// <summary>
        /// <para> This test verifies whether phone book is changed in an appropriate way. </para>
        /// </summary>

        [Test, TestCaseSource(nameof(TestDataForChangingFormatOfNumberFunction))]
        public void Should_Replace_All_Numbers_With_Specified_Format_In_DefaultFormat(string pattern,
            Dictionary<string, string> testPhoneBook, Dictionary<string, string> expectedPhoneBook)
        {
            var phoneBook = new PhoneBook(testPhoneBook);
            phoneBook.ChangeFormatOfNumbers(pattern);

            var expected = expectedPhoneBook;
            var actual = phoneBook.BookOfPhones;

            CollectionAssert.AreEqual(expected, actual, "Collections are not equal!");
        }
    }
}