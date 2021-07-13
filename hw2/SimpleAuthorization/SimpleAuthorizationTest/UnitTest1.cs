using System.Security.Authentication;
using NUnit.Framework;
using SimpleAuthorization;
using Authorization = SimpleAuthorization.Authorization;

namespace SimpleAuthorizationTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Authorization_CorrectData_ReturnsUserModel()
        {
            var actualResult = Authorization.Run(new string[]{ "admin", "root" });

            var expectedResult = new UserModel() {Username = "admin"};

            Assert.AreEqual(expectedResult.Username, actualResult.Username);
        }

        [Test]
        public void Authorization_NotValidUsername_ThrowsAuthException()
        {
            var ex = Assert.Throws<AuthenticationException>(() => Authorization.Run(new string[] {"vasya", "vasya"}));

            Assert.That(ex.Message == Constants.NotExistingUser);
        }

        [Test]
        public void Authorization_NotValidPasswd_ThrowsAuthException()
        {
            var ex = Assert.Throws<AuthenticationException>(() => Authorization.Run(new string[] { "admin", "notRoot" }));

            Assert.That(ex.Message == Constants.IncorrectPasswd);
        }
    }
}