using ExcelImport.Shared.ValueObject;

namespace ExcelImport.Models.User
{
    public class UserId : UUID
    {
        public UserId(string value) : base(value) {}
    }
}
