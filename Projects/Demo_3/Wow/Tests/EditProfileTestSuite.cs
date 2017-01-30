using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using Wow.Data;

namespace Wow.Tests
{
    [TestFixture]
    public class EditProfileTestSuite
    {
        private static readonly object[] TestData =
        {
            new object[]
            {
                UserRepository.Get().FromXml("Users.xml").GetAdmin(),
                "newpassword",      // New Password
                "passwordnew",      // Confirm Password 
                "Password and confirm password should be the same"  // Dialog window message 
            }
        };

        [Test, TestCase(nameof(TestData))]
        public void ErrorMessageTest(IUser admin, string newPassword, string confirmPassword)
        {

        }
    }
}
