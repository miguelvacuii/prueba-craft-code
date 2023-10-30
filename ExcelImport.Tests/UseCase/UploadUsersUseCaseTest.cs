using ExcelImport.Models.User;
using ExcelImport.Repository.User;
using ExcelImport.Tests.Models.User.Stub;
using ExcelImport.UseCase.Service;
using NUnit.Framework;
using Moq;
using ExcelImport.UseCases;
using ExcelImport.Shared.Service.FileProcessor;
using System.Collections.Generic;

namespace ExcelImport.Tests.UseCase
{

    [TestFixture]
    public class UploadUsersUseCaseTest
    {
        private User user;
        private List<User> userList;

        private HttpPostedFileBase fileUpload;

        private string path = "/users.xml";

        [SetUp]
        public void Setup()
        {
            user = UserStub.ByDefault();
            userList = new List<User>();
            userList.Add(user);

            fileUpload = new HttpPostedFileBase();
            fileUpload.ContentType = "application/vnd.ms-excel";
            fileUpload.FileName = "users.xls";
        }

        [Test]
        public void ItShouldCallCollaborators()
        {

            Mock<UserFileProcessService> userFileProcessService = CreatedAtAndSetupUserFileProcessServiceMock(path, userList);

            Mock<UserFactory> userFactory = CreatedAtAndSetupUserFactoryMock(user);

            Mock<IUserRepository> userRepository = CreatedAtAndSetupUserRepositoryMock();


            UploadUsersUseCase uploadUsersUseCase = new UploadUsersUseCase(
                userRepository.Object, userFactory.Object, userFileProcessService.Object
            );
            uploadUsersUseCase.Invoke(fileUpload);

            userFileProcessService.Verify(
                m => m.SaveFileAndReturnPath(It.IsAny<HttpPostedFileBase>()),
                Times.AtLeastOnce()
            );

            userFileProcessService.Verify(
                m => m.ProcessFileContent(It.IsAny<string>()),
                Times.AtLeastOnce()
            );

            userFactory.Verify(
                m => m.CreateUserFromSource(It.IsAny<object>()),
                Times.AtLeastOnce()
            );

            userRepository.Verify(
                m => m.Add(It.IsAny<User>()),
                Times.AtLeastOnce()
            );

            userFileProcessService.Verify(
                m => m.DeleteFile(It.IsAny<string>()),
                Times.AtLeastOnce()
            );
        }

        private Mock<UserFileProcessService> CreatedAtAndSetupUserFileProcessServiceMock(string path, List<User> userList)
        {
            Mock<UserFileProcessService> userFileProcessService = new Mock<UserFileProcessService>();
            userFileProcessService.Setup(m => m.SaveFileAndReturnPath(It.IsAny<HttpPostedFileBase>())).Returns(path);
            userFileProcessService.Setup(m => m.ProcessFileContent(It.IsAny<string>())).Returns(userList);
            userFileProcessService.Setup(m => m.DeleteFile(It.IsAny<string>())).Verifiable();
            return userFileProcessService;
        }

        private Mock<UserFactory> CreatedAtAndSetupUserFactoryMock(User user)
        {
            Mock<UserFactory> userFactory = new Mock<UserFactory>();
            userFactory.Setup(m => m.CreateUserFromSource(It.IsAny<object>())).Returns(user);
            return userFactory;
        }

        private Mock<IUserRepository> CreatedAtAndSetupUserRepositoryMock()
        {
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository.Setup(m => m.Add(It.IsAny<User>())).Verifiable();
            return userRepository;
        }
    }
}
