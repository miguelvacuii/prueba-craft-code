using ExcelImport.Shared.ValueObject.Exception;
using ExcelImport.Tests.Models.User.Stub;
using NUnit.Framework;

namespace ExcelImport.Tests.Models.User
{
    public class UserIdTest
    {
        [Test]
        public void ItShouldThrowExeptionWhenUserIdIsEmpty()
        {
            string userId = "";
            string message = "The UUID must not be empty";
            InvalidAttributeException exception = Assert.Throws<InvalidAttributeException>(
                () => UserIdStub.FromValue(userId)
            );

            Assert.That(exception.Message, Is.EqualTo(message));
        }

        [Test]
        public void ItShouldThrowExeptionWhenUserIdIsNotValid()
        {
            string userId = "xxx";
            string message = string.Format(
                "The UUID is invalid because of its value is {0}", userId
            );

            InvalidAttributeException exception = Assert.Throws<InvalidAttributeException>(
                () => UserIdStub.FromValue(userId)
            );

            Assert.That(exception.Message, Is.EqualTo(message));
        }
    }
}
