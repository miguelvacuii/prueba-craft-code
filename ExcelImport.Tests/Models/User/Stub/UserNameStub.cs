using ExcelImport.Models.User;

namespace ExcelImport.Tests.Models.User.Stub
{
    public class UserNameStub
    {
		public static UserName ByDefault()
		{
			return new UserName("Name");
		}

		public static UserName FromValue(string value)
		{
			return new UserName(value);
		}
	}
}
