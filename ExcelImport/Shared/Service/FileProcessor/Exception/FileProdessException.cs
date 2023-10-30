using ExcelImport.Shared.Exception;

namespace ExcelImport.Shared.Service.FileProcessor.Exception
{
    public class FileProcessException : ErrorException
    {
        public FileProcessException(string message) : base (message) {
        }

        public static FileProcessException FromNotFound()
        {
            return new FileProcessException("File not found in path");
        }

        public static FileProcessException FromNull()
        {
            return new FileProcessException("Please choose a file");
        }

        internal static System.Exception FromContentType(string format)
        {
            return new FileProcessException(string.Format("Only {0} format is allowed", format));
        }
    }
}
