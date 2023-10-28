using System;
namespace ExcelImport.Controllers.Exception
{
    public class InvalidFileException : FormatException
    {
        public InvalidFileException(string message) : base(message) { }

        public static InvalidFileException FromNull()
        {
            return new InvalidFileException(
                string.Format("Please choose Excel file")
            );
        }

        public static InvalidFileException FromContentType()
        {
            return new InvalidFileException(
                string.Format("Only Excel file format is allowed")
            );
        }
    }
}
