using ExcelImport.Models.User;

namespace ExcelImport.Tests.Models.User.Stub
{
    public class UserStub
    {

        public static User ByDefault()
        {
            return User.SignUp(
                UserIdStub.ByDefault(),
                UserNameStub.ByDefault(),
                UserAddressStub.ByDefault(),
                UserContactNumberStub.ByDefault()
            );
        }

        public static User FromValues(
            string id = "",
            string name = "",
            string address = "",
            string contactNumber = ""
        )
        {
            return User.Create(
                string.IsNullOrEmpty(id) ? UserIdStub.ByDefault() : UserIdStub.FromValue(id),
                string.IsNullOrEmpty(name) ? UserNameStub.ByDefault() : UserNameStub.FromValue(name),
                string.IsNullOrEmpty(address) ? UserAddressStub.ByDefault() : UserAddressStub.FromValue(address),
                string.IsNullOrEmpty(contactNumber) ? UserContactNumberStub.ByDefault() : UserContactNumberStub.FromValue(address)
            );
        }
    }
}
