using ExcelImport.Shared.Service.FileProcessor;
using ExcelImport.Shared.Service.FileProcessor.Exception;
using ExcelImport.UseCase.Service;
using Moq;
using NUnit.Framework;

namespace ExcelImport.Tests.UseCase.Service
{
    [TestFixture]
    public class UserFileProcessServiceTest
    {
        private HttpPostedFileBase fileUpload;

        [SetUp]
        public void Setup()
        {
            fileUpload = new HttpPostedFileBase();
            fileUpload.FileName = "users.xls";
            fileUpload.ContentType = "application/vnd.ms-excel";
        }

        [Test]
        public void SaveFileAndReturnPathItShouldThrowExceptionIfFileIsNull()
        {
            Mock<IFileProcessorLibrary> fileProcessorLibrary = new Mock<IFileProcessorLibrary>();
            Mock<IServer> server = new Mock<IServer>();
            UserFileProcessService userFileProcessService = new UserFileProcessService(fileProcessorLibrary.Object, server.Object);

            string message = "File not found in path";

            FileProcessException exception = Assert.Throws<FileProcessException>(
                () => userFileProcessService.SaveFileAndReturnPath(null)
            );

            Assert.That(exception.Message, Is.EqualTo(message));
        }

        [Test]
        public void SaveFileAndReturnPathItShouldThrowExceptionIfContentTypeIsNotXLS()
        {
            Mock<IFileProcessorLibrary> fileProcessorLibrary = new Mock<IFileProcessorLibrary>();
            Mock<IServer> server = new Mock<IServer>();
            UserFileProcessService userFileProcessService = new UserFileProcessService(fileProcessorLibrary.Object, server.Object);

            string message = "Only Excel format is allowed";

            HttpPostedFileBase fileUpload = new HttpPostedFileBase();
            fileUpload.FileName = "users.xls";
            fileUpload.ContentType = "application/word";

            FileProcessException exception = Assert.Throws<FileProcessException>(
                () => userFileProcessService.SaveFileAndReturnPath(fileUpload)
            );

            Assert.That(exception.Message, Is.EqualTo(message));
        }

        [Test]
        public void DeleteFileItShouldThrowExceptionIfFileNotFound()
        {
            Mock<IFileProcessorLibrary> fileProcessorLibrary = new Mock<IFileProcessorLibrary>();
            Mock<IServer> server = new Mock<IServer>();
            UserFileProcessService userFileProcessService = new UserFileProcessService(fileProcessorLibrary.Object, server.Object);

            string message = "File not found in path";

            FileProcessException exception = Assert.Throws<FileProcessException>(
                () => userFileProcessService.DeleteFile("")
            );

            Assert.That(exception.Message, Is.EqualTo(message));
        }
    }
}
