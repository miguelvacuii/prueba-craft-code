namespace ExcelImport.Shared.Service.FileProcessor
{
    public class ExcelQueryFactory : IFileProcessorLibrary
    {
        private ExcelQueryFactory() { }

        public dynamic ReadFile(string path) {
            return new ExcelFile();
        }
    }
}
