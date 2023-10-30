using ExcelImport.Models.User;

namespace ExcelImport.Tests.Models.User.Stub
{
    public class UserAddressStub
    {
		public static UserAddress ByDefault()
		{
			return new UserAddress("Address");
		}

		public static UserAddress FromValue(string value)
		{
			return new UserAddress(value);
		}
	}
}
