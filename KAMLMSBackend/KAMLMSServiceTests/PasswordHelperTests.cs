using KAMLMSService.Helper;
using NUnit.Framework;

namespace KAMLMSServiceTests
{
    [TestFixture]
    public class PasswordHelperTests
    {
        [Test]
        public void HashPassword_ShouldReturnNonNullHash_WhenPasswordIsProvided()
        {
            string password = "divyanshu@123";
            string hash = PasswordHelper.HashPassword(password);

            Assert.AreNotEqual(password, hash);
        }

        [Test]
        public void HashPassword_ShouldProduceConsistentHash_ForSameInput()
        {
            string password = "divyanshu@123";
            string hash1 = PasswordHelper.HashPassword(password);
            string hash2 = PasswordHelper.HashPassword(password);

            Assert.AreEqual(hash1, hash2);
        }

        [Test]
        public void VerifyPassword_ShouldReturnTrue_WhenPasswordMatchesHash()
        {
            string password = "divyanshu@123";
            string hash = PasswordHelper.HashPassword(password);
            bool result = PasswordHelper.VerifyPassword(password, hash);

            Assert.IsTrue(result);
        }

        [Test]
        public void VerifyPassword_ShouldReturnFalse_WhenPasswordDoesNotMatchHash()
        {
            string password = "hello@123";
            string wrongPassword = "divyanshu@123";
            string hash = PasswordHelper.HashPassword(password);

            bool result = PasswordHelper.VerifyPassword(wrongPassword, hash);

            Assert.IsFalse(result);
        }
    }
}
