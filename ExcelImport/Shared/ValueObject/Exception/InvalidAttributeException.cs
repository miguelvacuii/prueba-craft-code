namespace ExcelImport.Shared.ValueObject.Exception
{
    public class InvalidAttributeException : ValidationException
    {
        public InvalidAttributeException(string message) : base(message) { }

        public static InvalidAttributeException FromText(string text)
        {
            return new InvalidAttributeException(text);
        }

        public static InvalidAttributeException FromEmpty(string attribute)
        {
            return new InvalidAttributeException(
                string.Format("The {0} must not be empty", attribute)
            );
        }

        public static InvalidAttributeException FromValue(string attribute, string value)
        {
            return new InvalidAttributeException(
                string.Format("The {0} is invalid because of its value is {1}", attribute, value)
            );
        }

        public static InvalidAttributeException FromMinLength(string attribute, int length)
        {
            return new InvalidAttributeException(
                string.Format("Length {0} cannot be less than {1}", attribute, length)
            );
        }

        public static InvalidAttributeException FromMaxLength(string attribute, int length)
        {
            return new InvalidAttributeException(
                string.Format("Length {0} cannto be more than {1}", attribute, length)
            );
        }
    }

}
