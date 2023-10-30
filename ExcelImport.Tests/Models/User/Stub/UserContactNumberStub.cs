using ExcelImport.Models.User;

namespace ExcelImport.Tests.Models.User.Stub
{
    public class UserContactNumberStub
    {
		public static UserContactNumber ByDefault()
		{
			return new UserContactNumber("123456789");
		}

		public static UserContactNumber FromValue(string value)
		{
			return new UserContactNumber(value);
		}
	}
}
