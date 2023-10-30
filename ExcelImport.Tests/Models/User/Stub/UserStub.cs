using UserEntity = ExcelImport.Models.User;

namespace ExcelImport.Tests.Models.User.Stub
{
    public class UserStub
    {

        public static UserEntity.User ByDefault()
        {
            return UserEntity.User.Create(
                UserNameStub.ByDefault(),
                UserAddressStub.ByDefault(),
                UserContactNumberStub.ByDefault()
            );
        }

        public static UserEntity.User FromValues(
            string id = "",
            string name = "",
            string address = "",
            string contactNumber = ""
        )
        {
            return UserEntity.User.Create(
                string.IsNullOrEmpty(name) ? UserNameStub.ByDefault() : UserNameStub.FromValue(name),
                string.IsNullOrEmpty(address) ? UserAddressStub.ByDefault() : UserAddressStub.FromValue(address),
                string.IsNullOrEmpty(contactNumber) ? UserContactNumberStub.ByDefault() : UserContactNumberStub.FromValue(address)
            );
        }
    }
}
