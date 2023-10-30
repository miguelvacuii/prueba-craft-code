namespace ExcelImport.Shared.Service.FileProcessor
{
    public class Server : IServer
    {
        public Server() { }

        public string MapPath(string path) {
            return path;
        }
    }
}
