using ExcelImport.Shared.ValueObject.Exception;
using ExcelImport.Tests.Models.User.Stub;
using NUnit.Framework;

namespace ExcelImport.Tests.Models.User
{
    public class UserContactNumberTest
    {
        [Test]
        public void ItShouldThrowExeptionWhenUserContactNumberIsEmpty()
        {
            string userContactNumberStub = "";
            string message = "The UserContactNumber must not be empty";
            InvalidAttributeException exception = Assert.Throws<InvalidAttributeException>(
                () => UserContactNumberStub.FromValue(userContactNumberStub)
            );

            Assert.That(exception.Message, Is.EqualTo(message));
        }
    }
}
