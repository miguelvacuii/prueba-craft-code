using ExcelImport.Models.User;

namespace ExcelImport.UseCase.Service
{
    public class UserFactory
    {

        public User CreateUserFromSource(dynamic user) {
            UserName userName = new UserName(user.Name);
            UserAddress userAddress = new UserAddress(user.Address);
            UserContactNumber userContactNumber = new UserContactNumber(user.ContactNo);

            return User.Create(userName, userAddress, userContactNumber);
        }
    }
}
