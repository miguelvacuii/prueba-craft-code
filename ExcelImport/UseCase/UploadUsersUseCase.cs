using ExcelImport.Models.User;
using ExcelImport.Repository.User;
using ExcelImport.Shared.Service.FileProcessor;
using ExcelImport.UseCase.Service;

namespace ExcelImport.UseCases
{
    public class UploadUsersUseCase
    {
        private readonly IUserRepository repository;
        private readonly UserFactory userFactory;
        private readonly UserFileProcessService userFileProcessService;
        
        public UploadUsersUseCase(
            IUserRepository repository,
            UserFactory userFactory,
            UserFileProcessService userFileProcessService
        ) {
            this.repository = repository;
            this.userFactory = userFactory;
            this.userFileProcessService = userFileProcessService;
        }

        public void Invoke(HttpPostedFileBase fileUpload)
        {
            string pathToExcelFile = userFileProcessService.SaveFileAndReturnPath(fileUpload);

            dynamic userList = userFileProcessService.ProcessFileContent(pathToExcelFile);

            foreach (var user in userList)
            {
                User userUpdated = userFactory.CreateUserFromSource(user);
                repository.Add(userUpdated);
            }

            userFileProcessService.DeleteFile(pathToExcelFile);
        }
    }
}
