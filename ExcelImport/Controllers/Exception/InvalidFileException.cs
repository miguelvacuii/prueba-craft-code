namespace ExcelImport.Controllers.Exception
{
    public class InvalidFileException : System.Exception
    {
        public InvalidFileException(string message) : base(message) { }

        public static InvalidFileException FromNull()
        {
            return new InvalidFileException("Please choose Excel file");
        }

        public static InvalidFileException FromContentType()
        {
            return new InvalidFileException("Only Excel file format is allowed");
        }
    }
}
