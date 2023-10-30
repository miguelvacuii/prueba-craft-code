using ExcelImport.Shared.ValueObject.Exception;
using ExcelImport.Tests.Models.User.Stub;
using NUnit.Framework;

namespace ExcelImport.Tests.Models.User
{
    public class UserAddressTest
    {
        [Test]
        public void ItShouldThrowExeptionWhenUserAddressIsEmpty()
        {
            string userAddress = "";
            string message = "The UserAddress must not be empty";
            InvalidAttributeException exception = Assert.Throws<InvalidAttributeException>(
                () => UserAddressStub.FromValue(userAddress)
            );

            Assert.That(exception.Message, Is.EqualTo(message));
        }
    }
}
