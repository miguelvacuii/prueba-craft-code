using System;

namespace ExcelImport.Models.User
{
	public class User
	{
		public UserId id { get; private set; }
		public UserName name { get; private set; }
		public UserAddress address { get; private set; }
		public UserContactNumber contactNumber { get; private set; }

		private User(
			UserId id,
			UserName name,
			UserAddress address,
			UserContactNumber contactNumber
		) {
			this.id = id;
			this.name = name;
			this.address = address;
			this.contactNumber = contactNumber;
		}

		public static User Create(
			UserName name,
			UserAddress address,
			UserContactNumber contactNumber
		) {
			UserId id = new UserId(Guid.NewGuid().ToString());
			User user = new User(id, name, address, contactNumber);
			return user;
		}
	}
}
