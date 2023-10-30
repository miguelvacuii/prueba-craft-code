using ExcelImport.Shared.Exception;

namespace ExcelImport.Shared.ValueObject.Exception
{
	public class ValidationException : WarningException
	{
		public ValidationException(string message) : base(message) { }
	}
}
