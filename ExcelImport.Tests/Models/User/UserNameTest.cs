using ExcelImport.Shared.ValueObject.Exception;
using ExcelImport.Tests.Models.User.Stub;
using NUnit.Framework;

namespace ExcelImport.Tests.Models.User
{
    public class UserNameTest
    {
        [Test]
        public void ItShouldThrowExeptionWhenUserNameIsEmpty()
        {
            string userName = "";
            string message = "The UserName must not be empty";
            InvalidAttributeException exception = Assert.Throws<InvalidAttributeException>(
                () => UserNameStub.FromValue(userName)
            );

            Assert.That(exception.Message, Is.EqualTo(message));
        }
    }
}
