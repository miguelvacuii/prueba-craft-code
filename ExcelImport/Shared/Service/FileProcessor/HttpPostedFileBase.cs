namespace ExcelImport.Shared.Service.FileProcessor
{
    public class HttpPostedFileBase
    {
        public string ContentType { get; internal set; }
        public string FileName { get; internal set; }

        internal void SaveAs(string name)
        {
            //TO-DO
        }
    }
}