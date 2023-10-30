using ExcelImport.Shared.Service.FileProcessor.Exception;
using System.IO;

namespace ExcelImport.Shared.Service.FileProcessor
{
    public abstract class FileProcessService
    {
        private readonly IFileProcessorLibrary fileProcessorLibrary;
        private readonly IServer server;

        public FileProcessService(IFileProcessorLibrary fileProcessorLibrary, IServer server) {
            this.fileProcessorLibrary = fileProcessorLibrary;
            this.server = server;
        }

        public virtual string SaveFileAndReturnPath(HttpPostedFileBase file, string path) {
            string fileName = file.FileName;
            string targetPath = server.MapPath(path);
            file.SaveAs(targetPath + fileName);
            return targetPath + fileName;
        }

        public abstract dynamic ProcessFileContent(string path);

        public void DeleteFile(string path)
        {
            if (!File.Exists(path))
            {
                throw FileProcessException.FromNotFound();
            }
            File.Delete(path);
        }
    }
}
