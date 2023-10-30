using ExcelImport.Models.User;

namespace ExcelImport.Tests.Models.User.Stub
{
	public class UserIdStub
	{

		public static UserId ByDefault()
		{
			return new UserId("535525de-5c04-4030-972f-e7deb5ed1399");
		}

		public static UserId FromValue(string value)
		{
			return new UserId(value);
		}
	}
}
