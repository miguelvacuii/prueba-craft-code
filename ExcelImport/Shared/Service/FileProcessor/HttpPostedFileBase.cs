namespace ExcelImport.Shared.Service.FileProcessor
{
    public class HttpPostedFileBase
    {
        public string ContentType { get; set; }
        public string FileName { get; set; }

        internal void SaveAs(string name)
        {
            //TO-DO
        }
    }
}